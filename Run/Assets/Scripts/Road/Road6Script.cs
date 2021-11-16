using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road6Script : MonoBehaviour
{
    

    public Transform road1;
    
    private Vector3 transformCoin;

    private int pConz=3;
    
    void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, transform.position.z);
        transform.Translate(new Vector3(0,0,-1)*GamePlayScript.Instance.MovingSpeed*Time.deltaTime);
    }

    private void OnEnable()
    {
        spawnCoininRoad();
        SpawnIteminRoad();
        spawnTraininRoad();
    }

    public void spawnTraininRoad()
    {
        spawnTrain(ObjectPool.Instance.poolTran3.GetPooledObject(),new Vector3(0,0,transform.position.z-65));
        spawnTrain(ObjectPool.Instance.poolTran2.GetPooledObject(),new Vector3(3,0,transform.position.z+110));
        spawnTrain(ObjectPool.Instance.poolTran2.GetPooledObject(),new Vector3(-3,0,transform.position.z+110));
    }
    public void spawnCoininRoad()
    {
        
        transformCoin = new Vector3(-3, 1, transform.position.z-20);
        for (int i = 0; i < 5; i++)
        {
            spawnCoin(transformCoin);
            transformCoin += new Vector3(0, 0, pConz);
        }
        
        transformCoin = new Vector3(0, 1, transform.position.z-14);
        for (int i = 0; i < 6; i++)
        {
            spawnCoin(transformCoin);
            transformCoin += new Vector3(0, 0, pConz);
        }
        transformCoin = new Vector3(3, 1, transform.position.z-6);
        for (int i = 0; i < 6; i++)
        {
            spawnCoin(transformCoin);
            transformCoin += new Vector3(0, 0, pConz);
        }


    }

    public void SpawnIteminRoad()
    {

        if (GamePlayScript.Instance.timeSpawnItem>=20)
        {
            switch (Random.Range(0,2))
            {
                case 0:
                    spawnItem(ObjectPool.Instance.poolMagnet.GetPooledObject(),
                        new Vector3(40, 40, 40),new Vector3(3, .5f, transform.position.z-15));
                    
                    break;
                case 1:
                    spawnItem( ObjectPool.Instance.poolShoes.GetPooledObject(),
                        new Vector3(0.03f, 0.03f, 0.03f),new Vector3(3, .5f, transform.position.z-15));
                    break;
            }
            GamePlayScript.Instance.timeSpawnItem = 0;
        }
        
    }
    
    public void spawnCoin(Vector3 transformCoin)
    {
        GameObject coin = (GameObject)ObjectPool.Instance.poolCoin.GetPooledObject();
        if (coin != null)
        {
            coin.SetActive(true);
            coin.transform.SetParent(gameObject.transform);
            coin.transform.position = transformCoin;

        }
    }

    public void spawnItem(GameObject item,Vector3 scale,Vector3 transform)
    {
        GameObject itemspawn = item;
        if (itemspawn != null)
        {
            itemspawn.transform.localScale = scale;
            itemspawn.SetActive(true);
            itemspawn.transform.SetParent(gameObject.transform);
            itemspawn.transform.position = transform;
                
        }
    }

    public void spawnTrain(GameObject train,Vector3 transform)
    {
        GameObject trainspawn = train;
        if (trainspawn != null)
        {
            trainspawn.SetActive(true);
            trainspawn.transform.SetParent(gameObject.transform);
            trainspawn.transform.position = transform;
                
        }
    }
}
