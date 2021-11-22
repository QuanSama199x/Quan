using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [Header("TRAIN SECTION")]
    public Transform[] TrainPositions;
    public string[] TrainPrefabs;

    [Header("ITEM SECTION")]
    public Transform[] ItemPositions;
    public string[] ItemPrefabs;

     void Start()
    {
        spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(-3, 0, transform.position.z - 50));
        spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(3, 0, transform.position.z - 35));
        spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(0, 0, transform.position.z - 10));
    }

    public void SpawnTrain(Transform[] positions, string[] trainPrefabs)
    {

        spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(-3, 0, transform.position.z - 50));
        spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(3, 0, transform.position.z - 35));
        spawnTrain(ObjectPool.Instance.poolTrain[0].GetPooledObject(Resources.Load<GameObject>("Train/Train1")), new Vector3(0, 0, transform.position.z - 10));
        //spawn train and set train position to position param

        var randomIndex = 1;


        var trainObject = Resources.Load<GameObject>(" " + TrainPrefabs[randomIndex]);
        Instantiate(trainObject, positions[randomIndex]);
    }

    public void Load()
    {
        
    }


    public void spawnTrain(GameObject train, Vector3 transform)
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
