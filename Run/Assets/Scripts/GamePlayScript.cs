using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;

public class GamePlayScript : MonoBehaviour
{
    public static GamePlayScript Instance;
    public GameObject Player;
    public float timeDeath;

    public float timePlay;

    public void Awake()
    {
        Instance = this;
    }
    

    public float MovingSpeed;
    public float timeSpawnItem;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        timeSpawnItem = 0;
        Screen.orientation = ScreenOrientation.Portrait;
        MovingSpeed = 10;
        timePlay = 0;
        Time.timeScale = 0;
        timeDeath = 0;
        level = 1;
    }
    
    // Update is called once per frame
    void Update()
    {


            
            timeSpawnItem += Time.deltaTime;
            timePlay += Time.deltaTime;
            if (timePlay>=50)
            {
                timePlay = 0;
                MovingSpeed += 2;
                RecTransformUI.Instance.scaleScore++;
                level++;
                if (level>4)
                {
                    level = 4;
                }
            }

            if (isDeath)
            {
                timeDeath += 0.01f;
                if (Player.transform.position.y>0)
                {
                    Player.transform.position += new Vector3(0,-0.05f,-0);
                }

                if (Player.transform.position.z >= -3)
                {
                    Player.transform.position += new Vector3(0,0,-0.5f);
                }
            }

            if (timeDeath>=3)
            {
                ButtonScript.Instance.isComplete.SetActive(true);
                timeDeath = 0;
            }

    }

    private bool isDeath;
    public void Gameover()
    {
        Time.timeScale = 0f;
        SwipeManager.Instance.animatorPlayer.updateMode = AnimatorUpdateMode.UnscaledTime;
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,5);
        ButtonScript.Instance.isPlaying.SetActive(false);
        if (Random.Range(0,2)==1)
        {
            SwipeManager.Instance.animatorPlayer.SetBool("isDeath1", true);
        }
        else
        {
            SwipeManager.Instance.animatorPlayer.SetBool("isDeath2", true);
        }
        isDeath = true;
        SaveData.Instance.DataCoin += RecTransformUI.Instance.CountCoin;
        getHighScore();
        SaveData.Instance.Save();
        

    }

    public void getHighScore()
    {
        for (int  i= 0;  i< SaveData.Instance.highscore.Count; i++)
        {
            if ((int)RecTransformUI.Instance.Score>SaveData.Instance.highscore[i])
            {
                RecTransformUI.Instance.NewRecord.SetActive(true);
                RecTransformUI.Instance.medal.SetActive(true);
                RecTransformUI.Instance.countMedal.text = (i + 1).ToString();
                for (int j = 4; j > i; j--)
                {
                    SaveData.Instance.highscore[j ] = SaveData.Instance.highscore[j-1];
                }
                SaveData.Instance.highscore[i] =(int) RecTransformUI.Instance.Score;
                SaveData.Instance.saveHighScore();
                 return;
            }
        }
    }
    
}
