using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRoadScript : MonoBehaviour
{
    public static SpawnRoadScript Instance;

    private void Awake()
    {
        Instance =this;
    }

    public List<GameObject> listRoad;
    private int randomRoad;

    private Vector3 transformCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnroad(ObjectPool.Instance.poolRoad1.GetPooledObject(),new Vector3(0,-0.5f,100));
        spawnroad(ObjectPool.Instance.poolRoad4.GetPooledObject(),new Vector3(0,-0.5f,200));
        spawnroad(ObjectPool.Instance.poolRoad2.GetPooledObject(),new Vector3(0,-0.5f,300));

    }

    void Update()
    {
        if (listRoad.Count<4)
        {
            SpawnRoad(new Vector3(listRoad[2].transform.position.x,listRoad[2].transform.position.y,listRoad[2].transform.position.z+100));
        }
    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            listRoad.Remove(other.gameObject);
            other.gameObject.SetActive(false);
            
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Coin"||other.gameObject.tag== "magnet"||other.gameObject.tag== "Shoes")
        {
            other.transform.SetParent(null);
            other.transform.position = new Vector3(1000, 1000, 1000);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag=="Train")
        {
            other.transform.parent.gameObject.SetActive(false);
            other.transform.parent.gameObject.transform.SetParent(null);
            other.transform.parent.gameObject.transform.position= new Vector3(1000, 1000, 1000);
        }
        
        
    }


    public void SpawnRoad(Vector3 transformnewroad)
    {
        randomRoad = Random.Range(1, 5);
        switch (GamePlayScript.Instance.level)
        {
            case 1:
                switch (randomRoad)
                {
                    case 1:
                        spawnroad(ObjectPool.Instance.poolRoad1.GetPooledObject(),transformnewroad);
                        break;
                    case 2:
                        spawnroad(ObjectPool.Instance.poolRoad2.GetPooledObject(),transformnewroad);
                        break;
                    case 3:
                        spawnroad(ObjectPool.Instance.poolRoad3.GetPooledObject(),transformnewroad);
                        break;
                    case 4:
                        spawnroad(ObjectPool.Instance.poolRoad4.GetPooledObject(),transformnewroad);
                        break;
                }
                break;
            case 2:
                switch (randomRoad)
                {
                    case 1:
                        spawnroad(ObjectPool.Instance.poolRoad3.GetPooledObject(),transformnewroad);
                        break;
                    case 2:
                        spawnroad(ObjectPool.Instance.poolRoad4.GetPooledObject(),transformnewroad);
                        break;
                    case 3:
                        spawnroad(ObjectPool.Instance.poolRoad5.GetPooledObject(),transformnewroad);
                        break;
                    case 4:
                        spawnroad(ObjectPool.Instance.poolRoad6.GetPooledObject(),transformnewroad);
                        break;
                }
                break;
            case 3:
                switch (randomRoad)
                {
                    case 1:
                        spawnroad(ObjectPool.Instance.poolRoad5.GetPooledObject(),transformnewroad);
                        break;
                    case 2:
                        spawnroad(ObjectPool.Instance.poolRoad6.GetPooledObject(),transformnewroad);
                        break;
                    case 3:
                        spawnroad(ObjectPool.Instance.poolRoad7.GetPooledObject(),transformnewroad);
                        break;
                    case 4:
                        spawnroad(ObjectPool.Instance.poolRoad8.GetPooledObject(),transformnewroad);
                        break;
                }
                break;
            case 4:
                switch (randomRoad)
                {
                    case 1:
                        spawnroad(ObjectPool.Instance.poolRoad7.GetPooledObject(),transformnewroad);
                        break;
                    case 2:
                        spawnroad(ObjectPool.Instance.poolRoad8.GetPooledObject(),transformnewroad);
                        break;
                    case 3:
                        spawnroad(ObjectPool.Instance.poolRoad9.GetPooledObject(),transformnewroad);
                        break;
                    case 4:
                        spawnroad(ObjectPool.Instance.poolRoad10.GetPooledObject(),transformnewroad);
                        break;
                }
                break;
                
        }
        
        
    }

    public void spawnroad(GameObject roadspawn,Vector3 transformnewroad)
    {
        GameObject road = roadspawn;
        if (road != null)
        {
            road.SetActive(true);
            road.transform.position = transformnewroad;
            listRoad.Add(road);
        }
    }
    
    
    
        
}
