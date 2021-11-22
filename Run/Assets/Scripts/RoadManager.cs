using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public Road Road;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, transform.position.z);
        transform.Translate(new Vector3(0, 0, -1) * GamePlayScript.Instance.MovingSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        Road.OnEnable(SpawnRoadScript.key,transform.position.z,gameObject);
    }

}

[System.Serializable]

public class Road
{

    private Vector3 transformCoin;

    private int pConz = 3;


    public void OnEnable(int key, float transform,GameObject gameobject)
    {
            
        spawnCoininRoad(key,transform, gameobject);
        SpawnIteminRoad(key,transform, gameobject);               
        spawnTraininRoad(key,transform, gameobject);               
        SpawnBlockinRoad(key,transform, gameobject);

        /*spawnCoininRoad(transform, gameobject);
        SpawnIteminRoad(transform,gameobject);
        spawnTraininRoad(transform, gameobject);
        SpawnBlockinRoad(transform, gameobject);*/
    }

    public void spawnTraininRoad(int key,float transform,GameObject gameobject)
    {
        switch(key)
        {
            case 1:
                spawnTrain(0,"Train/Train1", new Vector3(-3, 0, transform - 50), gameobject);
                spawnTrain(0,"Train/Train1", new Vector3(3, 0, transform - 35), gameobject);
                spawnTrain(0,"Train/Train1", new Vector3(0, 0, transform - 10), gameobject);
                break;
            case 2:
                spawnTrain(2, "Train/Train3", new Vector3(-3, 0, transform - 65), gameobject);
                spawnTrain(0, "Train/Train1", new Vector3(0, 0, transform - 40), gameobject);
                spawnTrain(0, "Train/Train1", new Vector3(-3, 0, transform - 20), gameobject);
                /*spawnTrain(ObjectPool.Instance.poolTrain[2].GetPooledObject(Resources.Load<GameObject>("Train/Train3")), new Vector3(-3, 0, transform - 65), gameobject);
                spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(0, 0, transform - 40), gameobject);
                spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(-3, 0, transform- 20), gameobject);*/
                break;
            case 3:
                spawnTrain(0,"Train/Train1", new Vector3(-3, 0, transform - 60), gameobject);
                spawnTrain(0,"Train/Train1", new Vector3(3, 0, transform - 50), gameobject);
                break;
            case 4:
                spawnTrain(2,"Train/Train3", new Vector3(0, 0, transform - 65), gameobject);
                spawnTrain(0,"Train/Train1", new Vector3(3, 0, transform - 40), gameobject);
                spawnTrain(0,"Train/Train1", new Vector3(0, 0, transform - 25), gameobject);
                break;
            case 5:
                spawnTrain(2,"Train/Train3", new Vector3(3, 0, transform - 60), gameobject);
                spawnTrain(1,"Train/Train2", new Vector3(0, 0, transform + 110), gameobject);
                spawnTrain(1,"Train/Train2", new Vector3(0, 0, transform + 150), gameobject);
                spawnTrain(0,"Train/Train1", new Vector3(-3, 0, transform - 10), gameobject);
                break;
            case 6:
                spawnTrain(2,"Train/Train3", new Vector3(0, 0, transform - 65), gameobject);
                spawnTrain(1,"Train/Train2", new Vector3(3, 0, transform + 110), gameobject);
                spawnTrain(1,"Train/Train2", new Vector3(-3, 0, transform + 110), gameobject);
                break;
            case 7:
                spawnTrain(2,"Train/Train3", new Vector3(-3, 0, transform - 60), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(0, 0, transform + 250), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(0, 0, transform + 300), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(0, 0, transform + 350), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(0, 0, transform + 400), gameobject);
                break;
            case 8:
                spawnTrain(1,"Train/Train2", new Vector3(3, 0, transform + 70), gameobject);
                spawnTrain(1,"Train/Train2", new Vector3(-3, 0, transform + 120), gameobject);
                spawnTrain(1,"Train/Train2", new Vector3(0, 0, transform + 170), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(0, 0, transform + 190), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(0, 0, transform + 262.2222f), gameobject);
                spawnTrain(3,"Train/Train4", new Vector3(3, 0, transform + 334.4445f), gameobject);
                break;
            case 9:
                spawnTrain(0,"Train/Train1", new Vector3(-3, 0, transform - 65), gameobject);
                spawnTrain(6,"Train/Train7", new Vector3(3, 0, transform - 65), gameobject);
                spawnTrain(6,"Train/Train7", new Vector3(-3, 0, transform - 15), gameobject);
                spawnTrain(4,"Train/Train5", new Vector3(3, 0, transform - 15), gameobject);
                spawnTrain(5,"Train/Train6", new Vector3(0, 0, transform - 40), gameobject);
                spawnTrain(5,"Train/Train6", new Vector3(0, 0, transform + 10), gameobject);
                break;
            case 10:
                spawnTrain(6,"Train/Train7", new Vector3(-3, 0, transform - 60), gameobject);
                spawnTrain(6,"Train/Train7", new Vector3(3, 0, transform + 10), gameobject);
                spawnTrain(5,"Train/Train6", new Vector3(0, 0, transform - 45), gameobject);
                spawnTrain(5,"Train/Train6", new Vector3(0, 0, transform - 5), gameobject);
                spawnTrain(5,"Train/Train6", new Vector3(-3, 0, transform + 20), gameobject);
                spawnTrain(4,"Train/Train5", new Vector3(-3, 0, transform - 40), gameobject);
                spawnTrain(4,"Train/Train5", new Vector3(3, 0, transform - 30), gameobject);
                spawnTrain(4,"Train/Train5", new Vector3(-3, 0, transform - 10), gameobject);
                break;
        }
        
    }
    public void spawnCoininRoad(int key, float transform,GameObject gameobject)
    {
        switch(key)
        {
            case 1:
                SpawnCoin(new Vector3(0, 1, transform - 30), 5, transformCoin, gameobject);
                SpawnCoin(new Vector3(-1.5f, 1, transform - 16.5f), 1, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 1, transform - 15), 5, transformCoin, gameobject);
                break;
            case 2:
                SpawnCoin(new Vector3(3, 1, transform - 22), 7, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 4, transform - 22), 5, transformCoin, gameobject);
                break;
            case 3:
                SpawnCoin(new Vector3(0, 1, transform - 15), 6, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 1, transform - 15), 5, transformCoin, gameobject);
                SpawnCoin(new Vector3(3, 1, transform - 15), 5, transformCoin, gameobject);
                break;
            case 4:
                SpawnCoin(new Vector3(-3, 1, transform - 30), 6, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 1, transform), 3, transformCoin, gameobject);
                SpawnCoin(new Vector3(-1.5f, 1, transform + 7.5f), 1, transformCoin, gameobject);
                SpawnCoin(new Vector3(0, 1, transform + 9), 3, transformCoin, gameobject);
                break;
            case 5:
                SpawnCoin(new Vector3(3, 4, transform - 50), 6, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 4, transform- 10), 6, transformCoin, gameobject);
                break;
            case 6:
                SpawnCoin(new Vector3(-3, 1, transform - 20), 5, transformCoin, gameobject);
                SpawnCoin(new Vector3(0, 1, transform - 14), 6, transformCoin, gameobject);
                SpawnCoin(new Vector3(3, 1, transform - 6), 6, transformCoin, gameobject);
                break;
            case 7:
                SpawnCoin(new Vector3(-3, 4, transform - 50), 6, transformCoin, gameobject);
                SpawnCoin(new Vector3(3, 1, transform + 5), 6, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 1, transform - 15), 5, transformCoin, gameobject);
                break;
            case 9:
                SpawnCoin(new Vector3(3, 1, transform - 45), 4, transformCoin, gameobject);
                SpawnCoin(new Vector3(1.5f, 1,transform -34.5f), 1, transformCoin, gameobject);
                SpawnCoin(new Vector3(0, 1, transform - 33), 4, transformCoin, gameobject);
                SpawnCoin(new Vector3(-3, 1, transform + 5), 6, transformCoin, gameobject);
                break;
            case 10:
                SpawnCoin(new Vector3(3, 1, transform - 49), 5, transformCoin, gameobject);
                SpawnCoin(new Vector3(1.5f, 1,transform -35.5f), 1, transformCoin, gameobject);
                SpawnCoin(new Vector3(0, 1, transform - 34), 4, transformCoin, gameobject);
                SpawnCoin(new Vector3(3, 1, transform - 10), 5, transformCoin, gameobject);
                break;
        }

        /*transformCoin = new Vector3(0, 1, transform - 30);
        for (int i = 0; i < 5; i++)
        {
            SpawnCoin(transformCoin, gameobject);
            transformCoin += new Vector3(0, 0, pConz);
        }
        SpawnCoin(new Vector3(-1.5f, 1, transform - 16.5f), gameobject);

        transformCoin = new Vector3(-3, 1, transform - 15);
        for (int i = 0; i < 5; i++)
        {
            SpawnCoin(transformCoin, gameobject);
            transformCoin += new Vector3(0, 0, pConz);
        }*/

    }

    public void SpawnIteminRoad(int key, float transform,GameObject gameobject)
    {

        if (GamePlayScript.Instance.timeSpawnItem >= 20)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    spawnItem("Item/magnet",new Vector3(40, 40, 40), new Vector3(3, .5f, transform - 15), gameobject);

                    break;
                case 1:
                    spawnItem("Item/Shoes",new Vector3(0.03f, 0.03f, 0.03f), new Vector3(3, .5f, transform - 15), gameobject);
                    break;
            }

            GamePlayScript.Instance.timeSpawnItem = 0;
        }

    }

    public void SpawnBlockinRoad(int key, float transform,GameObject gameobject)
    {
        switch(key)
        {
            case 1:
                SpawnBlocker(0, "Blocker/Block1", new Vector3(-3, 0.8f, transform + 10), gameobject);
                SpawnBlocker(0, "Blocker/Block1", new Vector3(0, 0.8f, transform - 47.2f), gameobject);
                break;
            case 2:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(3, 0.8f, transform - 30), gameobject);
                break;
            case 3:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(0, 0.8f, transform + 11.01f), gameobject);
                SpawnBlocker(1,"Blocker/Block2", new Vector3(0, 0.8f, transform - 59.69f), gameobject);
                break;
            case 4:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(-3, 0.8f, transform + -47.75f), gameobject);
                SpawnBlocker(0,"Blocker/Block1", new Vector3(0, 0.8f, transform + 19.3f), gameobject);
                SpawnBlocker(1,"Blocker/Block2", new Vector3(-3, 0.8f, transform - 22), gameobject);
                break;
            case 5:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(3, 0.8f, transform), gameobject);
                SpawnBlocker(1,"Blocker/Block2", new Vector3(-3, 0.8f, transform - 40), gameobject);
                SpawnBlocker(2,"Blocker/Block3", new Vector3(0, 0.8f, transform), gameobject);
                break;
            case 6:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(-3, 0.8f, transform), gameobject);
                SpawnBlocker(2,"Blocker/Block3", new Vector3(0, 0.8f, transform), gameobject);
                SpawnBlocker(0,"Blocker/Block1", new Vector3(3, 0.8f, transform), gameobject);
                break;
            case 7:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(3, 0.8f, transform), gameobject);
                SpawnBlocker(2,"Blocker/Block3", new Vector3(0, 0.8f, transform), gameobject);
                break;
            case 8:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(-3, 0.8f, transform), gameobject);
                SpawnBlocker(0,"Blocker/Block1", new Vector3(0, 0.8f, transform), gameobject);
                SpawnBlocker(2,"Blocker/Block3", new Vector3(0, 0.8f, transform - 73.4f), gameobject);
                break;
            case 9:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(0, 0.8f, transform - 55), gameobject);
                SpawnBlocker(0,"Blocker/Block1", new Vector3(3, 0.8f, transform + 6.1f), gameobject);
                SpawnBlocker(1,"Blocker/Block2", new Vector3(3, 0.8f, transform - 40), gameobject);
                SpawnBlocker(1,"Blocker/Block2", new Vector3(-3, 0.8f, transform + 10), gameobject);
                SpawnBlocker(2,"Blocker/Block3", new Vector3(0, 0.8f, transform - 20), gameobject);
                break;
            case 10:
                SpawnBlocker(0,"Blocker/Block1", new Vector3(3, 0.8f, transform - 55), gameobject);
                SpawnBlocker(1,"Blocker/Block2", new Vector3(0, 0.8f, transform + 10), gameobject);
                SpawnBlocker(2,"Blocker/Block3", new Vector3(0, 0.8f, transform - 20), gameobject);
                break;
        }
    }

    public void SpawnCoin(Vector3 newTransformCoin ,int countSpawn,Vector3 transformCoin, GameObject gameobject)
    {
        transformCoin = newTransformCoin;
        for(int i=0;i<countSpawn; i++)
        {
            GameObject coin = (GameObject)ObjectPool.Instance.poolCoin.GetPooledObject(Resources.Load<GameObject>("Item/Coin"));
            if (coin != null)
            {
                coin.SetActive(true);
                coin.transform.SetParent(gameobject.transform);
                coin.transform.position = transformCoin;
                transformCoin += new Vector3(0, 0, pConz);

            }
        }
        /*GameObject coin = (GameObject)ObjectPool.Instance.poolCoin.GetPooledObject(Resources.Load<GameObject>("Item/Coin"));
        if (coin != null)
        {
            coin.SetActive(true);
            coin.transform.SetParent(gameobject.transform);
            coin.transform.position = transformCoin;

        }*/
    }

    /*public void SpawnCoin1(Vector3 transformCoin,GameObject gameobject)
    {
        GameObject coin = (GameObject)ObjectPool.Instance.poolCoin.GetPooledObject(Resources.Load<GameObject>("Item/Coin"));
        if (coin != null)
        {
            coin.SetActive(true);
            coin.transform.SetParent(gameobject.transform);
            coin.transform.position = transformCoin;
        }
    }*/

    public void spawnItem(string item, Vector3 scale, Vector3 transform,GameObject gameobject)
    {
        GameObject itemspawn = ObjectPool.Instance.poolShoes.GetPooledObject(Resources.Load<GameObject>(item));
        if (itemspawn != null)
        {
            itemspawn.transform.localScale = scale;
            itemspawn.SetActive(true);
            itemspawn.transform.SetParent(gameobject.transform);
            itemspawn.transform.position = transform;

        }
    }

    public void SpawnBlocker(int type,string blocker, Vector3 transform, GameObject gameobject)
    {
        GameObject blockerspawn = ObjectPool.Instance.PoolBlocker[type].GetPooledObject(Resources.Load<GameObject>(blocker));
        if (blockerspawn != null)
        {
            blockerspawn.SetActive(true);
            blockerspawn.transform.SetParent(gameobject.transform);
            blockerspawn.transform.position = transform;
        }
    }

    /*public void spawnTrain1(GameObject train, Vector3 transform, GameObject gameobject)
    {
        GameObject trainspawn = train;
        if (trainspawn != null)
        {
            trainspawn.SetActive(true);
            trainspawn.transform.SetParent(gameobject.transform);
            trainspawn.transform.position = transform;

        }
    }*/
    public void spawnTrain(int typeTrain, string nameTrain, Vector3 transform, GameObject gameobject)
    {
        GameObject trainspawn = ObjectPool.Instance.poolTrain[typeTrain].GetPooledObject(Resources.Load<GameObject>(nameTrain));
        if (trainspawn != null)
        {
            trainspawn.SetActive(true);
            trainspawn.transform.SetParent(gameobject.transform);
            trainspawn.transform.position = transform;

        }
    }
}
