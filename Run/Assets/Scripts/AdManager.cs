using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    private static AdManager instance;
    public static AdManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<AdManager>();
            return instance;
        }
    }
    private BannerView bannerAd;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();


    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);



        this.bannerAd.OnAdLoaded += BannerAd_OnAdLoaded;
        this.bannerAd.OnAdFailedToLoad += BannerAd_OnAdFailedToLoad;
        this.bannerAd.OnAdClosed += BannerAd_OnAdClosed;


        AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(request);

        
    }

    private void BannerAd_OnAdClosed(object sender, EventArgs e)
    {
        Debug.LogError("ad closed");
    }

    private void BannerAd_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        Debug.LogError("ad failed to load ");
    }

    private void BannerAd_OnAdLoaded(object sender, EventArgs e)
    {
        this.bannerAd.Show();
    }

    // Update is called once per frame
    void Update()
    {

    }


}


