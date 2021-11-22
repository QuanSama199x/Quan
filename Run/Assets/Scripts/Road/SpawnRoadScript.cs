using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRoadScript : MonoBehaviour
{
    public static int key;
    public static SpawnRoadScript Instance;

    private void Awake()
    {
        Instance =this;
    }

    public List<GameObject> listRoad;
    private int randomRoad;

    private Vector3 transformCoin;
    
    // Start is called before the first frame update
  
    public void isStart()
    {
        key = 1;
        spawnroad(ObjectPool.Instance.PoolRoadDemo.GetPooledObject(Resources.Load<GameObject>("Road/RoadDemo")), new Vector3(0, -0.5f, 100));
        key = 4;
        spawnroad(ObjectPool.Instance.PoolRoadDemo.GetPooledObject(Resources.Load<GameObject>("Road/RoadDemo")), new Vector3(0, -0.5f, 200));
        key = 2;
        spawnroad(ObjectPool.Instance.PoolRoadDemo.GetPooledObject(Resources.Load<GameObject>("Road/RoadDemo")), new Vector3(0, -0.5f, 300));
        /*spawnroad(ObjectPool.Instance.poolRoad[0].GetPooledObject(Resources.Load<GameObject>("Road/Road1")), new Vector3(0, -0.5f, 100));
        spawnroad(ObjectPool.Instance.poolRoad[3].GetPooledObject(Resources.Load<GameObject>("Road/Road4")), new Vector3(0, -0.5f, 200));
        spawnroad(ObjectPool.Instance.poolRoad[1].GetPooledObject(Resources.Load<GameObject>("Road/Road2")), new Vector3(0, -0.5f, 300));*/
    }

    void Update()
    {
        if (listRoad.Count < 4)
        {
            SpawnRoad(new Vector3(listRoad[2].transform.position.x, listRoad[2].transform.position.y, listRoad[2].transform.position.z + 100));
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
        if(other.gameObject.name == "Block1(Clone)" || other.gameObject.name == "Block2(Clone)" || other.gameObject.name == "Block3(Clone)")
        {
            other.transform.SetParent(null);
            other.transform.position =new Vector3(1000, 1000, 1000);
            other.gameObject.SetActive(false);
        }
        
        
    }


    public void SpawnRoad(Vector3 transformnewroad)
    {
        key = Random.Range(1, 11);
        spawnroad(ObjectPool.Instance.PoolRoadDemo.GetPooledObject(Resources.Load<GameObject>("Road/RoadDemo")), transformnewroad);
        /*switch (GamePlayScript.Instance.level)
        {
            *//*case 1:
                spawnroad(ObjectPool.Instance.poolRoad[randomRoad].GetPooledObject(Resources.Load<GameObject>("Road/Road" + (randomRoad + 1))), transformnewroad);

                break;
            case 2:
                spawnroad(ObjectPool.Instance.poolRoad[randomRoad].GetPooledObject(Resources.Load<GameObject>("Road/Road" + (randomRoad + 1))), transformnewroad);
                break;
            case 3:
                spawnroad(ObjectPool.Instance.poolRoad[randomRoad].GetPooledObject(Resources.Load<GameObject>("Road/Road" + (randomRoad + 1))), transformnewroad);
                break;
            case 4:
                spawnroad(ObjectPool.Instance.poolRoad[randomRoad].GetPooledObject(Resources.Load<GameObject>("Road/Road" + (randomRoad + 1))), transformnewroad);
                break;*//*

        }*/


    }

    /*public void spawnroad(GameObject roadspawn,Vector3 transformnewroad)
    {
        GameObject road = roadspawn;
        if (road != null)
        {
            road.SetActive(true);
            road.transform.position = transformnewroad;
            listRoad.Add(road);
        }
    }*/
    public void spawnroad(GameObject roadspawn, Vector3 transformnewroad)
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
