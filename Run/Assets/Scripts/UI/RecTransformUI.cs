using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class RecTransformUI : MonoBehaviour
{
    public static RecTransformUI Instance;

    public float scaleX;
    public float scaleY;
    private void Awake()
    {
        Instance = this;
    }

    #region isPlaying
    public float Score;
    public int Score0,Score1, Score2, Score3, Score4, Score5,scaleScore;
    public Text textScore;
    public Text textScaleScore;
    public RectTransform rectextScore;

    public RectTransform recCompleteTable;

    public int CountCoin;
    public Text textCoin;
    public Text textCoinGameOver;
    public RectTransform rectextCoin;

    public RectTransform reccountdown;
    public Image countdownItem;
    public GameObject magnet;
    public GameObject shoes;

    public RectTransform recPause;
    public RectTransform recPauseTable;
    public RectTransform recSetting;

    public RectTransform recIconShield;
    public GameObject iconShield;
    public bool haveShield;
    public GameObject buttonBuyShield;
    public RectTransform recbuttonBuyShield;
    public float timebuttonBuyShield;
    public Image timeUseShield;
    public GameObject buttonShield;
    #endregion

    #region isMenu

    public RectTransform recSettingM;
    public RectTransform rectabtoPlay;
    public RectTransform recSelectChar;
    public RectTransform recDataCoin;
    public RectTransform rectableHighScore;
    public RectTransform recbuttonHighScore;
    public RectTransform rectableBuyChar;
    public RectTransform buttonReset;

    public Text textDataCoin;
    public RectTransform text;
    private float  y,x;
    
    public List<Text> highscore;
    

    #endregion
    
    public Text textScoreGameOver;
    public GameObject NewRecord;
    public GameObject medal;
    public Text countMedal;


    

    // Start is called before the first frame update
    void Start()
    {
        buttonBuyShield.SetActive(true);
        haveShield = false;
        scaleX = (float)Screen.width / 480;
        scaleY = (float)Screen.height / 800;

        y = 0;
        x = 0;
        Score = 0;
        scaleScore = 1;
        
        magnet.SetActive(false);
        shoes.SetActive(false);
        
        RecTransform(rectextScore);
        RecTransform(recCompleteTable);
        RecTransform(rectextCoin);
        RecTransform(reccountdown);
        RecTransform(recPause);
        RecTransform(recPauseTable);
        RecTransform(recSetting);
        RecTransform(recSettingM);
        RecTransform(rectabtoPlay);
        RecTransform(recSelectChar);
        RecTransform(recDataCoin);
        RecTransform(rectableHighScore);
        RecTransform(recbuttonHighScore);
        RecTransform(buttonReset);
        RecTransform(rectableBuyChar);
        RecTransform(recIconShield);
        RecTransform(recbuttonBuyShield);
    }

    // Update is called once per frame


    private bool up1,up2;
    void Update()
    {
        text.Rotate(0,0,0.3f);
        text.localPosition = new Vector2(x, y);
        if (text.localPosition.y>=200)
        {
            up1 = true;
        }
        if (text.localPosition.y<=-200)
        {
            up1 = false;
        }
        if (!up1)
        {
            y += 0.2f;
        }

        if (up1)
        {
            y -= 0.2f;
        }
        if (text.localPosition.y>=80)
        {
            up2 = true;
        }
        if (text.localPosition.y<=-80)
        {
            up2 = false;
        }
        if (!up2)
        {
            x += 0.1f;
        }

        if (up2)
        {
            x -= 0.1f;
        }
        TextScore();
        TextCoin();
        countdownItem.fillAmount = (float) PlayerScript.Instance.timeGetItem / 15;

        textDataCoin.text = SaveData.Instance.DataCoin.ToString();

        if (haveShield)
        {
            iconShield.SetActive(true);
        }
        else
        {
            iconShield.SetActive(false);
        }

        if (buttonBuyShield.activeInHierarchy)
        {
            timebuttonBuyShield += Time.deltaTime;
        }
        if (timebuttonBuyShield>=4)
        {
            buttonBuyShield.SetActive(false);
        }

    }
    
    public void TextScore()
    {
        Score += (float) Time.deltaTime * 11 * scaleScore;
        textScaleScore.text = scaleScore.ToString();
        Score0 = (int) Score / 100000;
        Score1 = (int) (Score-Score0*100000) / 10000;
        Score2 = (int) (Score - Score0*100000 - Score1 * 10000) / 1000;
        Score3 = (int) (Score - Score0*100000 - Score1 * 10000-Score2*1000) / 100;
        Score4 = (int) (Score - Score0*100000 - Score1 * 10000-Score2*1000 - Score3*100) / 10;
        Score5 = (int)Score - Score0*100000 -Score1*10000- Score2*1000 -Score3*100-Score4*10;
        textScore.text =Score0.ToString()+ Score1.ToString() + Score2.ToString()+Score3.ToString()+Score4.ToString()+Score5.ToString();
        textScoreGameOver.text = ((int)Score).ToString();
    }

    #region MyRegion

    public void TextCoin()
    {
        textCoin.text = CountCoin.ToString();
        textCoinGameOver.text = textCoin.text;
    }

    
    

    #endregion
    

    public void RecTransform(RectTransform getTransform)
    {
        getTransform.transform.localPosition = new Vector2(getTransform.transform.localPosition.x*scaleX,getTransform.transform.localPosition.y*scaleY);
        getTransform.localScale = new Vector2(scaleX,scaleX);
    }
}
