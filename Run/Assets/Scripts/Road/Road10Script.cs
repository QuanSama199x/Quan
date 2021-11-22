using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road10Script : MonoBehaviour
{

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
        SpawnBlockinRoad();
    }

    public void spawnTraininRoad()
    {
        spawnTrain(ObjectPool.Instance.poolTrain[6].GetPooledObject(Resources.Load<GameObject>("Train/Train7")),new Vector3(-3,0,transform.position.z-60));
        spawnTrain(ObjectPool.Instance.poolTrain[6].GetPooledObject(Resources.Load<GameObject>("Train/Train7")),new Vector3(3,0,transform.position.z+10));
        spawnTrain(ObjectPool.Instance.poolTrain[5].GetPooledObject(Resources.Load<GameObject>("Train/Train6")),new Vector3(0,0,transform.position.z-45));
        spawnTrain(ObjectPool.Instance.poolTrain[5].GetPooledObject(Resources.Load<GameObject>("Train/Train6")),new Vector3(0,0,transform.position.z-5));
        spawnTrain(ObjectPool.Instance.poolTrain[5].GetPooledObject(Resources.Load<GameObject>("Train/Train6")),new Vector3(-3,0,transform.position.z+20));
        spawnTrain(ObjectPool.Instance.poolTrain[4].GetPooledObject(Resources.Load<GameObject>("Train/Train5")),new Vector3(-3,0,transform.position.z-40));
        spawnTrain(ObjectPool.Instance.poolTrain[4].GetPooledObject(Resources.Load<GameObject>("Train/Train5")),new Vector3(3,0,transform.position.z-30));
        spawnTrain(ObjectPool.Instance.poolTrain[4].GetPooledObject(Resources.Load<GameObject>("Train/Train5")),new Vector3(-3,0,transform.position.z-10));
    }
    public void spawnCoininRoad()
    {
        
        transformCoin = new Vector3(3, 1, transform.position.z-49);
        for (int i = 0; i < 5; i++)
        {
            spawnCoin(transformCoin);
            transformCoin += new Vector3(0, 0, pConz);
        }
        spawnCoin(new Vector3(1.5f,1,-35.5f));
        transformCoin = new Vector3(0, 1, transform.position.z-34);
        for (int i = 0; i < 4; i++)
        {
            spawnCoin(transformCoin);
            transformCoin += new Vector3(0, 0, pConz);
        }
        transformCoin = new Vector3(3, 1, transform.position.z-10);
        for (int i = 0; i < 5; i++)
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
                    spawnItem(ObjectPool.Instance.poolMagnet.GetPooledObject(Resources.Load<GameObject>("Item/magnet")),
                        new Vector3(40, 40, 40),new Vector3(3, .5f, transform.position.z-15));
                    
                    break;
                case 1:
                    spawnItem( ObjectPool.Instance.poolShoes.GetPooledObject(Resources.Load<GameObject>("Item/Shoes")),
                        new Vector3(0.03f, 0.03f, 0.03f),new Vector3(3, .5f, transform.position.z-15));
                    break;
            }
            GamePlayScript.Instance.timeSpawnItem = 0;
        }
        
    }

    public void SpawnBlockinRoad()
    {
        SpawnBlocker(ObjectPool.Instance.PoolBlocker[0].GetPooledObject(Resources.Load<GameObject>("Blocker/Block" + 1)), new Vector3(3, 0.8f, transform.position.z-55));
        SpawnBlocker(ObjectPool.Instance.PoolBlocker[1].GetPooledObject(Resources.Load<GameObject>("Blocker/Block" + 2)), new Vector3(0, 0.8f, transform.position.z+10));
        SpawnBlocker(ObjectPool.Instance.PoolBlocker[2].GetPooledObject(Resources.Load<GameObject>("Blocker/Block" + 3)), new Vector3(0, 0.8f, transform.position.z - 20));
    }

    public void spawnCoin(Vector3 transformCoin)
    {
        GameObject coin = (GameObject)ObjectPool.Instance.poolCoin.GetPooledObject(Resources.Load<GameObject>("Item/Coin"));
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

    public void SpawnBlocker(GameObject blocker, Vector3 transform)
    {
        GameObject blockerspawn = blocker;
        if (blockerspawn != null)
        {
            blockerspawn.SetActive(true);
            blockerspawn.transform.SetParent(gameObject.transform);
            blockerspawn.transform.position = transform;
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
