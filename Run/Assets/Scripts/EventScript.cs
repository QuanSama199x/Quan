using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventScript : MonoBehaviour
{
    private static EventScript instance;
    public static EventScript Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EventScript>();
            return instance;
        }
    }
    public UnityEvent OnGetCoin;
    public UnityEvent LvUp;
    public UnityEvent isPlay;

    void Start()
    {
        LvUp = new UnityEvent();
        OnGetCoin = new UnityEvent();
        isPlay = new UnityEvent();


        OnGetCoin.AddListener(Config.Instance.AddCoin);
        OnGetCoin.AddListener(Config.Instance.AddScore);
        OnGetCoin.AddListener(RecTransformUI.Instance.TextCoin);

        LvUp.AddListener(Config.Instance.UpScaleCore);

        isPlay.AddListener(RecTransformUI.Instance.IsPlay);
    }

}
