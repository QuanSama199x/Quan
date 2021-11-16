using System;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static SwipeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public  bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public GameObject emty;
    public GameObject Player;
    
    public int XValue;
    public static int jumpPower;

    private float timeroll;
    public Animator animatorPlayer;

    public bool countJump;

    public GameObject colliderPlayer;


    public Vector3 nonEmty;

    void Start()
    {
        nonEmty.x = emty.transform.position.x;
        countJump = true;
        timeroll = 0;
        jumpPower = 6;
    }

    void Update()
    {
        if (Mathf.Abs(emty.transform.position.x - Player.transform.position.x)<=1)
        {
            nonEmty.x =emty.transform.position.x;
        }
        emty.transform.position = new Vector3(emty.transform.position.x,Player.transform.position.y,Player.transform.position.z);
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
        if (Time.timeScale==1)
        {
            #region Standalone Inputs
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }
            #endregion

            #region Mobile Input
            if (Input.touches.Length > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    tap = true;
                    isDraging = true;
                    startTouch = Input.touches[0].position;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDraging = false;
                    Reset();
                }
            }
            #endregion
        }
        

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0&& timeroll==0)
                {
                    
                    swipeDown = true;
                    PlayerScript.Instance.isroll = true;
                    
                }
                if (y>0 &&countJump==true)
                {
                    swipeUp = true;
                    timeroll = 1;
                }
                    
            }

            if (swipeLeft)
            {
                moveLeft();
            }

            if (swipeRight)
            {
                moveRight();
            }

            if (swipeUp)
            {
                countJump = false;
                Jump();
            }

            if (swipeDown)
            {
                Down();
            }

            



            Reset();
        }
        Player.transform.position = Vector3.Lerp(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z),
            new Vector3(emty.transform.position.x, Player.transform.position.y, Player.transform.position.z), 5 * Time.deltaTime);



        if (Mathf.Abs(Player.transform.position.x - emty.transform.position.x) <=0.3&& Player.transform.forward!= Vector3.zero)
        {
            Player.transform.forward = Vector3.zero;
            
        }

        if (istimeroll)
        {
            colliderPlayer.gameObject.transform.localScale = new Vector3(1,0.5f,1);
            timeroll += Time.deltaTime;
            
        }
        if (timeroll>=1)
        {
            colliderPlayer.gameObject.transform.localScale = new Vector3(1,1,1);
            animatorPlayer.SetBool("isRoll",false);
            timeroll = 0;
            istimeroll = false;
        }

    }

    public bool istimeroll;
    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
    
    
    
    public void moveLeft()
    {
        if (emty.transform.position.x==0&& Vector3.Distance(Player.transform.position,emty.transform.position)<=1f)
        {
            emty.transform.position = new Vector3(-XValue, 0.5f, 0);
        }
        if (emty.transform.position.x==3&& Vector3.Distance(Player.transform.position,emty.transform.position)<=1f)
        {
            emty.transform.position = new Vector3(0, 0.5f, 0);
        }

        Player.transform.forward = new Vector3(-10, 0, 10);

    }
    
    public void moveRight()
    {
        if (emty.transform.position.x==0&& Vector3.Distance(Player.transform.position,emty.transform.position)<=0.5f)
        {
            emty.transform.position = new Vector3(XValue, 0.5f, 0);
        }
        if (emty.transform.position.x==-3&& Vector3.Distance(Player.transform.position,emty.transform.position)<=0.5f)
        {
            emty.transform.position = new Vector3(0, 0.5f, 0);
        }
        Player.transform.forward = new Vector3(1, 0, 1);

    }

    public bool isjump;

    public void Jump()
    {
        Player.GetComponent<Rigidbody>().velocity= new Vector3(0, jumpPower, 0);
        animatorPlayer.SetBool("isJump", true);
        isjump = true;
        /*transform.position = new Vector3(transform.position.x, 4, transform.position.z);*/

    }
    public void Down()
    {
        Player.GetComponent<Rigidbody>().velocity= new Vector3(0, -jumpPower*2, 0);
        /*transform.position = new Vector3(transform.position.x, 4, transform.position.z);*/
        
    }
}