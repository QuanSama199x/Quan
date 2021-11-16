using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public static ButtonScript Instance;

    public AudioSource tab;
    
    public GameObject isPlaying;
    public GameObject isMenu;
    public GameObject isComplete;
    public GameObject pauseTable;
    public GameObject SettingTable;
    public GameObject TableChar;
    public List<GameObject> checkbuy;
    /*public GameObject blockKlee,blockQiqi,blockDiona,blockPaimon;*/
    public GameObject tableBuyChar;
    public GameObject buyKlee,buyQiqi, buyDiona,buyPaimon,buyElaina,buyHuman;

    public Scrollbar volume;

    public GameObject tableHighScore;


    public AudioSource AudioBG;

    
    public Image selectChar;

    public List<Image> iconChar;
    public List<Avatar> avtChar;
    public List<GameObject> Char;

    public int setChar;

    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        isPlaying.SetActive(false);
        isComplete.SetActive(false);
        isMenu.SetActive(true);
        pauseTable.SetActive(false);
        SettingTable.SetActive(false);
        TableChar.SetActive(false);

        volume.value = 1;

    }

    // Update is called once per frame
    void Update()
    {
        AudioBG.volume=volume.value;
    }
    
    public void ButtonNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        tab.Play();

    }

    public void ButtonPause()
    {
        SwipeManager.Instance.Reset();
        Time.timeScale = 0;
        pauseTable.SetActive(true);
        tab.Play();
        
    }

    public bool isPlay;
    public void ButtonPlay()
    {
        isPlay = true;
        Time.timeScale = 1;
        isMenu.SetActive(false);
        isPlaying.SetActive(transform);
        SwipeManager.Instance.animatorPlayer.SetBool("isPlay",true);
        SwipeManager.Instance.animatorPlayer.updateMode = AnimatorUpdateMode.Normal;
        tab.Play();
    }
    

    public void ButtonContinue()
    {
        SwipeManager.Instance.Reset();
        Time.timeScale = 1;
        pauseTable.SetActive(false);
        tab.Play();
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        tab.Play();
    }

    public void ButtonSetting()
    {
        SettingTable.SetActive(true);
        tab.Play();
    }

    public void ButtonXSetting()
    {
        SettingTable.SetActive(false);
        tab.Play();
    }

    public void buttonUseShield()
    {
        PlayerScript.Instance.isHaveShield = true;
        PlayerScript.Instance.powerShield = 3;
        RecTransformUI.Instance.buttonShield.SetActive(false);
    }

    public void buttonBuyShield()
    {
        if (SaveData.Instance.DataCoin>=100)
        {
            RecTransformUI.Instance.buttonBuyShield.SetActive(false);
            RecTransformUI.Instance.haveShield = true;
            SaveData.Instance.DataCoin -= 100;
            SaveData.Instance.Save();
        }
    }

    #region Char

    

    
    public void SelectChar()
    {
        if (TableChar.activeInHierarchy)
        {
            TableChar.SetActive(false);
        }
        else
        {
            TableChar.SetActive(true);
        }
        tab.Play();
        
    }

    public void chooseKlee()
    {
        setChar = 3;
        chooseChar();
    }

    public void chooseQiqi()
    {
        setChar = 4;
        chooseChar();
    }
    public void chooseDiona()
    {
        setChar = 1;
        chooseChar();
    }
    public void choosePaimon()
    {
        setChar = 2;
        chooseChar();
    }
    public void chooseHili()
    {
        setChar = 0;
        chooseChar();
    }
    public void chooseElaina()
    {
        setChar = 5;
        chooseChar();
    }
    public void chooseHuman()
    {
        setChar = 6;
        chooseChar();
    }

    public void chooseChar()
    {
        TableChar.SetActive(false);
        selectChar.sprite = iconChar[setChar].sprite;
        
        
        SwipeManager.Instance.animatorPlayer.avatar =avtChar[setChar];
        PlayerScript.Instance.shoeLeft.transform.SetParent(PlayerScript.Instance.left[setChar].transform);
        PlayerScript.Instance.shoeRight.transform.SetParent(PlayerScript.Instance.right[setChar].transform);
        PlayerScript.Instance.magnet.transform.SetParent(PlayerScript.Instance.hand[setChar].transform);
        SaveData.Instance.checkSelectChar = setChar;
        for (int i = 0; i < Char.Count; i++)
        {
            if (i==setChar)
            {
                Char[i].SetActive(true);
            }
            else
            {
                Char[i].SetActive(false);
            }
        }
        SaveData.Instance.Save();

        
        tab.Play();
    }

    public void buttonblockKlee()
    {
        tableBuyChar.SetActive(true);
        buyKlee.SetActive(true);
        tab.Play();
    }
    public void buttonblockQiqi()
    {
        tableBuyChar.SetActive(true);
        buyQiqi.SetActive(true);
        tab.Play();
    }
    public void buttonblockDiona()
    {
        tableBuyChar.SetActive(true);
        buyDiona.SetActive(true);
        tab.Play();
    }
    public void buttonblockPaimon()
    {
        tableBuyChar.SetActive(true);
        buyPaimon.SetActive(true);
        tab.Play();
    }
    public void buttonblockElaina()
    {
        tableBuyChar.SetActive(true);
        buyElaina.SetActive(true);
        tab.Play();
    }
    public void buttonblockHuman()
    {
        tableBuyChar.SetActive(true);
        buyHuman.SetActive(true);
        tab.Play();
    }
    
    
    public void BuyKlee()
    {
        if ( buyChar(800,checkbuy[2],buyKlee))
        {
            SaveData.Instance.boolcheckbuy[2] = true;
            SaveData.Instance.Save();
        }
    }

    public void BuyQiqi()
    {
        if (buyChar(800, checkbuy[3], buyQiqi))
        {
            SaveData.Instance.boolcheckbuy[3] = true;
            SaveData.Instance.Save();
        }
        
    }
    public void BuyPaimon()
    {
        if (buyChar(500, checkbuy[1], buyPaimon))
        {
            SaveData.Instance.boolcheckbuy[1] = true;
            SaveData.Instance.Save();
        }
        
    }
    public void BuyDiona()
    {
        if (buyChar(350, checkbuy[0], buyDiona))
        {
            SaveData.Instance.boolcheckbuy[0] = true;
            SaveData.Instance.Save();
        }
        
    }
    public void BuyElaina()
    {
        if (buyChar(600, checkbuy[4], buyElaina))
        {
            SaveData.Instance.boolcheckbuy[4] = true;
            SaveData.Instance.Save();
        }
        
    }
    public void BuyHuman()
    {
        if (buyChar(1000, checkbuy[5], buyHuman))
        {
            SaveData.Instance.boolcheckbuy[5] = true;
            SaveData.Instance.Save();
        }
        
    }
    public bool buyChar(int price,GameObject block,GameObject buychar)
    {
        if (SaveData.Instance.DataCoin>=price)
        {
            SaveData.Instance.DataCoin -= price;
            block.SetActive(false);
            tableBuyChar.SetActive(false);
            buychar.SetActive(false);
            tab.Play();

            return true;
        }
        else
        {
            tableBuyChar.SetActive(false);
            buychar.SetActive(false);
            tab.Play();

            return false;
        }
    }

    public void buttonXBuyChar()
    {
        tableBuyChar.SetActive(false);
        buyDiona.SetActive(false);
        buyElaina.SetActive(false);
        buyHuman.SetActive(false);
        buyKlee.SetActive(false);
        buyQiqi.SetActive(false);
        buyPaimon.SetActive(false);
        tab.Play();
    }
    #endregion


    public void buttonopenHighScore()
    {
        tableHighScore.SetActive(true);
    }
    
    public void buttoncloseHighScore()
    {
        tableHighScore.SetActive(false);
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    public void resetData()
    {
        SaveData.Instance.resetData();
        tab.Play();
    }

}
