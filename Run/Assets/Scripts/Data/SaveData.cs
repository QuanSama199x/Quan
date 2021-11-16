using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    public List<bool> boolcheckbuy;

    public List<int> highscore;
    
    private void Awake()
    {
        Instance = this;
    }

    public int DataCoin=0;

    public int checkSelectChar;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < highscore.Count; i++)
        {
            highscore[i] = 0;
        }
        
        loadData();
        loadHighScore();
        Save();
        for (int i = 0; i < highscore.Count; i++)
        {
            RecTransformUI.Instance.highscore[i].text ="No."+(i+1).ToString()+": "+ highscore[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Coin",DataCoin);
        for (int i = 0; i < boolcheckbuy.Count; i++)
        {
            PlayerPrefs.SetInt("checkbuy"+i,boolcheckbuy[i]?1:0);
        }

        PlayerPrefs.SetInt("checkselectchar", checkSelectChar);
        PlayerPrefs.Save();
    }

    public void saveHighScore()
    {
        for (int i = 0; i < highscore.Count; i++)
        {
            PlayerPrefs.SetInt("highscore"+i,highscore[i]);
        }
    }

    public void loadHighScore()
    {
        for (int i = 0; i < highscore.Count; i++)
        {
            highscore[i] =PlayerPrefs.GetInt("highscore"+i);
        }
    }
    public void loadData()
    {


        DataCoin = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("Coin",DataCoin);
        for (int i = 0; i < boolcheckbuy.Count; i++)
        {
            if (PlayerPrefs.GetInt("checkbuy"+i)==1)
            {
                boolcheckbuy[i] = true;
                ButtonScript.Instance.checkbuy[i].SetActive(false);
            }
            else
            {
                ButtonScript.Instance.checkbuy[i].SetActive(true);
                boolcheckbuy[i] = false;
            }
            
            
        }

        checkSelectChar = PlayerPrefs.GetInt("checkselectchar");
        switch (checkSelectChar)
        {
            case 0 :
                ButtonScript.Instance.chooseHili();
                break;
            case 1 :
                ButtonScript.Instance.chooseDiona();
                break;
            case 2 :
                ButtonScript.Instance.choosePaimon();
                break;
            case 3 :
                ButtonScript.Instance.chooseKlee();
                break;
            case 4 :
                ButtonScript.Instance.chooseQiqi();
                break;
            case 5 :
                ButtonScript.Instance.chooseElaina();
                break;
            case 6 :
                ButtonScript.Instance.chooseHuman();
                break;
        }
    }

    public void resetData()
    {
        DataCoin = 0;
        checkSelectChar = 0;
        for (int i = 0; i < boolcheckbuy.Count; i++)
        {
            boolcheckbuy[i] = false;
            PlayerPrefs.SetInt("checkbuy"+i,boolcheckbuy[i]?1:0);
        }

        for (int i = 0; i < highscore.Count; i++)
        {
            highscore[i] = 0;
        }
        Save();
        saveHighScore();
    }
}
