using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPoolVFX : MonoBehaviour
{
    public static ObjectPoolVFX Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<ParticleSystem> PooledVFXgetCoin;
    public int amountToPoolVFXgetCoin;
    public ParticleSystem VFXgetCoin;
    // Start is called before the first frame update
    void Start()
    {
        startVFX(PooledVFXgetCoin,amountToPoolVFXgetCoin,VFXgetCoin);
    }
    
    public ParticleSystem GetPooledVFXgetCoin(Vector3 position) {return GetPooledVFX(PooledVFXgetCoin, VFXgetCoin,position); }
    
    
    
    
    
    
    public void startVFX(List<ParticleSystem> PooledParticleSystem, int amountToPool, ParticleSystem ParticleSystemtoPool)
    { 
        for (int i = 0; i < amountToPool; i++) { 
            var obj = Instantiate(ParticleSystemtoPool); 
            obj.Stop(); 
            PooledParticleSystem.Add(obj); 
        }
    }

    public ParticleSystem GetPooledVFX(List<ParticleSystem> PooledParticleSystem,ParticleSystem ParticleSystemtoPool,Vector3 position)
    {
        for (int i = 0; i < PooledParticleSystem.Count; i++) {
            if (!PooledParticleSystem[i].isStopped)
            {
                PooledParticleSystem[i].transform.position = position;
                return PooledParticleSystem[i]; 
            }
        }
        var obj = Instantiate(ParticleSystemtoPool); 
        obj.Stop();
        obj.transform.position = position;
        PooledParticleSystem.Add(obj); 
        return obj;
    }
}