using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private static Config instance;
    public static Config Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Config>();
            return instance;
        }
    }
    public int Coin;
    public int scaleCoin = 1;
    public float Score;
    public int basicScore=11;
    public int scaleScore;
    // Start is called before the first frame update
    void Start()
    {
        scaleScore = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Score += (float)Time.deltaTime * basicScore * scaleScore;
    }


    public void UpScaleCore()
    {
        scaleScore += 1;
    }
    public void AddCoin()
    {
        Coin += scaleCoin;
        RecTransformUI.Instance.TextCoin();
    }
    public void AddScore()
    {
        Score += basicScore * scaleScore;
    }
}
