using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    
    public static PlayerScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject shoeLeft, shoeRight,magnet;
    
    public List<GameObject> left;
    public List<GameObject> right;
    public List<GameObject> hand;

    private Vector3 viewPoint;

    public bool isroll;

    public float timeStun;

    public float timeIdle;
    public bool idle, dance;
    public float timeDance;

    public bool isHaveShield;
    public GameObject shield;
    public int powerShield;
    public float timeUseShield;
    /*private float t;*/

    public float timeGetItem;
    // Start is called before the first frame update
    void Start()
    {
        timeUseShield = 0;
        shield.SetActive(false);
        isHaveShield = false;
        idle = true;
        /*t = 0;*/
        magnet.SetActive(false);
        shoeLeft.SetActive(false);
        shoeRight.SetActive(false);
        timeGetItem = 0;
        timeStun = 4;
            viewPoint = new Vector3(0, 5.22f,-4.73f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ButtonScript.Instance.isPlay)
        {
            if (idle)
            {
                timeIdle += 0.002f;
                if (timeIdle>=2)
                {
                    idle = false;
                    dance = true;
                    timeIdle = 0;
                    SwipeManager.Instance.animatorPlayer.SetInteger("Dance",Random.Range(1,4));
                }
            }

            if (dance)
            {
                timeDance += 0.002f;
                if (timeDance>=5)
                {
                    idle = true;
                    dance = false;
                    timeDance = 0;
                    SwipeManager.Instance.animatorPlayer.SetInteger("Dance",0);
                }
            }
            
        }
        Camera.main.transform.position = Vector3.Lerp(new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y,Camera.main.transform.position.z), new Vector3(transform.position.x,viewPoint.y,Camera.main.transform.position.z), 5 * Time.deltaTime);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y,
            transform.position.z - 4.73f);
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        


        /*Camera.main.transform.position = new Vector3(transform.position.x,transform.position.y+2,transform.position.z);*/

        if (isGetMagnet)
        {
            GetMagnet();
        }
        if (isGetShoes)
        {
            getShoes();
        }

        if (isStun)
        {
            timeStun -= Time.deltaTime;
            if (timeStun<=0)
            {
                timeStun = 4;
                isStun = false;
                SwipeManager.Instance.animatorPlayer.SetBool("isStun",false);
            }
        }

        if (isHaveShield)
        {
            timeUseShield += Time.deltaTime;
            RecTransformUI.Instance.timeUseShield.fillAmount =(float) timeUseShield / 20;
            shield.SetActive(true);
            if (timeUseShield>=20)
            {
                RecTransformUI.Instance.haveShield = false;
                isHaveShield = false;
            }
        }

        if (!isHaveShield)
        {
            shield.SetActive(false);
            timeUseShield = 0;
        }
        
        
        
    }


    public void OnCollisionEnter(Collision other)
    {
        if (isStun)
        {
            SwipeManager.Instance.animatorPlayer.SetBool("isStun",true);
        }
        else
        {
            SwipeManager.Instance.animatorPlayer.SetBool("isJump",false);
        }
        if (SwipeManager.Instance.isjump&& !isroll)
        {
            SwipeManager.Instance.isjump = false;
            SwipeManager.Instance.animatorPlayer.SetBool("isJump",false);
        }
        
        
    }
    

    public bool isStun;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Coin" )
        {
            RecTransformUI.Instance.CountCoin+=2;
            RecTransformUI.Instance.Score += RecTransformUI.Instance.scaleScore * 10;
            ObjectPoolVFX.Instance.GetPooledVFXgetCoin(other.transform.position).Play();
            ObjectPoolSFX.Instance.GetPooledSFXgetCoin(other.transform.position).Play();
            other.transform.SetParent(null);
            other.transform.position = new Vector3(1000, 1000, 1000);
            other.gameObject.SetActive(false);
        }
        if (isHaveShield)
        {
            switch (other.gameObject.name)
            {
                case "Block1":
                    powerShield -= 1;
                    break;
                case "Block2":
                    powerShield -= 1;
                    break;
                case "Block3":
                    powerShield -= 1;
                    break;
                case "Шапка_1_9":
                    other.gameObject.transform.parent.transform.parent.transform.parent.transform.parent.gameObject.SetActive(false);
                    other.gameObject.transform.parent.transform.parent.transform.parent.transform.parent.SetParent(null);
                    powerShield -= 1;
                    break;
                case "nonBlocker":
                    other.gameObject.transform.parent.gameObject.SetActive(false);
                    other.gameObject.transform.parent.SetParent(null);
                    powerShield -= 1;
                    break;
            }
            if (powerShield<=0)
            {
                isHaveShield = false;
            }
        }
        else
        {
            switch (other.gameObject.tag)
            {
                case "Blocker":
                    GamePlayScript.Instance.Gameover();
                    break;
                case "nonBlocker":
                    Debug.LogError("vacham " + other.name + " " + other.GetHashCode());
                    other.name = other.GetHashCode().ToString();
                    if (isStun)
                    {
                        GamePlayScript.Instance.Gameover();
                        Debug.LogError("x");
                    }
                    else
                    {
                        SwipeManager.Instance.animatorPlayer.SetBool("isStun",true);
                        Debug.LogError(SwipeManager.Instance.emty.transform.position);
                        SwipeManager.Instance.emty.transform.position = new Vector3(SwipeManager.Instance.nonEmty.x, SwipeManager.Instance.emty.transform.position.y, SwipeManager.Instance.emty.transform.position.z);
                        Debug.LogError(SwipeManager.Instance.emty.transform.position);
                        isStun = true;
                    }
                    break;
            }
        }
        

        if (other.gameObject.tag== "magnet")
        {
            isGetMagnet = true;
            other.transform.SetParent(null);
            other.transform.position = new Vector3(1000, 1000, 1000);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag== "Shoes")
        {
            isGetShoes = true;
            other.transform.SetParent(null);
            other.transform.position = new Vector3(1000, 1000, 1000);
            other.gameObject.SetActive(false);
        }
    }
    
    public void OnCollisionStay(Collision other)
    {
        viewPoint = other.gameObject.tag switch
        {
            "Road" => new Vector3(0, 5.22f, -4.73f),
            "Train" => new Vector3(0, 8.3789f, -4.73f),
            _ => viewPoint
        };
        /*if (other.gameObject.name == "Куб_5 (1)")
        {
            GetComponent<Rigidbody>().velocity = Vector3.up;
        }*/
        if (other.gameObject.tag =="Train")
        {
            SwipeManager.Instance.animatorPlayer.SetBool("isJump",false);
        }
        if(other.gameObject.tag == "Road"||other.gameObject.tag == "Train")
        {
            SwipeManager.Instance.countJump = true;
            
            if (isroll)
            {
                /*SwipeManager.Instance.animatorPlayer.Play("Roll");*/
                SwipeManager.Instance.animatorPlayer.SetBool("isRoll",true);
                SwipeManager.Instance.istimeroll = true;
                isroll = false;
                
            }
            
        }
    }
    public void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Road"||other.gameObject.tag == "Train")
        {
            
            SwipeManager.Instance.countJump = false;
        }
        if(other.gameObject.tag == "Train")
        {
            
            SwipeManager.Instance.animatorPlayer.SetBool("isJump",true);
        }

        /*if (other.gameObject.name == "Куб_5 (1)")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }*/
    }


    public bool isGetMagnet;
    public bool isGetShoes;
    private static readonly int Dance = Animator.StringToHash("Dance");


    public void getShoes()
    {
        shoeLeft.SetActive(true);
        shoeRight.SetActive(true);
        SwipeManager.jumpPower = 9;
        timeGetItem += Time.deltaTime;
        RecTransformUI.Instance.shoes.SetActive(true);
        if (timeGetItem>=15)
        {
            RecTransformUI.Instance.shoes.SetActive(false);
            SwipeManager.jumpPower = 6;
            isGetShoes = false;
            timeGetItem = 0;
            shoeLeft.SetActive(false);
            shoeRight.SetActive(false);
        }
        
    }
    public void GetMagnet()
    {
        magnet.SetActive(true);
        timeGetItem += Time.deltaTime;
        RecTransformUI.Instance.magnet.SetActive(true);
        if (timeGetItem>=15)
        {
            RecTransformUI.Instance.magnet.SetActive(false);
            isGetMagnet = false;
            timeGetItem = 0;
            magnet.SetActive(false);
        }
    }
}
