using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPoolSFX : MonoBehaviour
{
    public static ObjectPoolSFX Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<AudioSource> PooledSFXgetCoin;
    public int amountToPoolSFXgetCoin;
    public AudioSource SFXgetCoin;
    // Start is called before the first frame update
    void Start()
    {
        startSFX(PooledSFXgetCoin,amountToPoolSFXgetCoin,SFXgetCoin);
    }
    
    public AudioSource GetPooledSFXgetCoin(Vector3 position) {return GetPooledSFX(PooledSFXgetCoin, SFXgetCoin,position); }
    
    
    
    
    
    
    public void startSFX(List<AudioSource> PooledAudioSource, int amountToPool, AudioSource AudioSourcetoPool)
    { 
        for (int i = 0; i < amountToPool; i++) { 
            var obj = Instantiate(AudioSourcetoPool); 
            obj.Stop(); 
            PooledAudioSource.Add(obj); 
        }
    }

    public AudioSource GetPooledSFX(List<AudioSource> PooledAudioSource,AudioSource AudioSourcetoPool,Vector3 position)
    {
        for (int i = 0; i < PooledAudioSource.Count; i++) {
            if (!PooledAudioSource[i].isPlaying)
            {
                PooledAudioSource[i].transform.position = position;
                return PooledAudioSource[i]; 
            }
        }
        var obj = Instantiate(AudioSourcetoPool); 
        obj.Stop();
        obj.transform.position = position;
        PooledAudioSource.Add(obj); 
        return obj;
    }
}