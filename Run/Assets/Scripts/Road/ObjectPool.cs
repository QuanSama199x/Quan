using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    void Awake() {
        Instance = this;
    }

    public PoolElement poolMagnet, poolShoes;
    public PoolElement poolCoin;
    public PoolElement poolTran1, poolTran2, poolTran3, poolTran4,poolTran5,poolTran6,poolTran7;
    public PoolElement poolRoad1, poolRoad2, poolRoad3, poolRoad4, poolRoad5, poolRoad6, poolRoad7, poolRoad8,poolRoad9,poolRoad10;

    private void Start()
    {
        poolMagnet.Start();poolShoes.Start();
        poolCoin.Start();
        poolTran1.Start();poolTran2.Start();poolTran3.Start();poolTran4.Start();poolTran5.Start();poolTran6.Start();poolTran7.Start();
        poolRoad1.Start();poolRoad2.Start();poolRoad3.Start();poolRoad4.Start();
        poolRoad5.Start();poolRoad6.Start();poolRoad7.Start();
        poolRoad8.Start();poolRoad9.Start();poolRoad10.Start();
    }


    #region MyRegion

    /*public void isStart()
    {
        PooledObjectsRoad1 = new List<GameObject>();
        PooledObjectsRoad2 = new List<GameObject>();
        PooledObjectsRoad3 = new List<GameObject>();
        PooledObjectsRoad4 = new List<GameObject>();
        PooledObjectsRoad5 = new List<GameObject>();
        startRoad(PooledObjectsRoad1,amountToPoolRoad1,ObjectToPoolRoad1);
        startRoad(PooledObjectsRoad2,amountToPoolRoad2,ObjectToPoolRoad2);
        startRoad(PooledObjectsRoad3,amountToPoolRoad3,ObjectToPoolRoad3);
        startRoad(PooledObjectsRoad4,amountToPoolRoad4,ObjectToPoolRoad4);
        startRoad(PooledObjectsRoad5,amountToPoolRoad5,ObjectToPoolRoad5);
    }

    

    #region Road1

    public List<GameObject> PooledObjectsRoad1;
    public GameObject ObjectToPoolRoad1;
    public int amountToPoolRoad1;
    public GameObject GetPooledObjectRoad1() {return GetPooledObject(PooledObjectsRoad1, ObjectToPoolRoad1); }
    #endregion

    #region Road2
    
    public List<GameObject> PooledObjectsRoad2;
    public GameObject ObjectToPoolRoad2; 
    public int amountToPoolRoad2;
    public GameObject GetPooledObjectRoad2() {return GetPooledObject(PooledObjectsRoad2, ObjectToPoolRoad2); }
    #endregion
       
    #region Road3

    public List<GameObject> PooledObjectsRoad3;
    public GameObject ObjectToPoolRoad3;
    public int amountToPoolRoad3;
    public GameObject GetPooledObjectRoad3() {return GetPooledObject(PooledObjectsRoad3, ObjectToPoolRoad3); }
    #endregion
        
    #region Road4

    public List<GameObject> PooledObjectsRoad4;
    public GameObject ObjectToPoolRoad4;
    public int amountToPoolRoad4;
    public GameObject GetPooledObjectRoad4() {return GetPooledObject(PooledObjectsRoad4, ObjectToPoolRoad4); }
    #endregion
        
    #region Road5

    public List<GameObject> PooledObjectsRoad5;
    public GameObject ObjectToPoolRoad5;
    public int amountToPoolRoad5;
    public GameObject GetPooledObjectRoad5() {return GetPooledObject(PooledObjectsRoad5, ObjectToPoolRoad5); }
    #endregion

    
    
    
    
    
    
    public void startRoad(List<GameObject> PooledObjects, int amountToPool, GameObject ObjecttoPool)
    { 
        for (int i = 0; i < amountToPool; i++) { 
            var obj = Instantiate(ObjecttoPool); 
            obj.SetActive(false); 
            PooledObjects.Add(obj); 
        }
    }

    public GameObject GetPooledObject(List<GameObject> PooledObjects,GameObject ObjecttoPool)
    {
        for (int i = 0; i < PooledObjects.Count; i++) {
            if (!PooledObjects[i].activeInHierarchy) { 
                return PooledObjects[i]; 
            }
        }
        GameObject obj = Instantiate(ObjecttoPool); 
        obj.SetActive(false); 
        PooledObjects.Add(obj); 
        return obj;
    }*/

    #endregion
}

[System.Serializable]
public class PoolElement
{
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool; 
    public int amountToPool;

    public void Start()
    {
        for (int i = 0; i < amountToPool; i++) { 
            var obj = GameObject.Instantiate(ObjectToPool); 
            obj.SetActive(false); 
            PooledObjects.Add(obj);
        }
    }
    

    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < PooledObjects.Count; i++) {
            if (!PooledObjects[i].activeInHierarchy) {
                return PooledObjects[i];
                
            }
        }
        GameObject obj = GameObject.Instantiate(ObjectToPool); 
        obj.SetActive(false); 
        PooledObjects.Add(obj); 
        return obj;
    }
}