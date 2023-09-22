using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private ObjectPooler objectPooler;
    private GameObject[] objectToPool;

    public void Start()
    {
        objectPooler = GameObject.Find("SpawnManager").GetComponent<ObjectPooler>();
        SpawnFoodForPool();
    }

    private void SpawnFoodForPool()
    {
        objectToPool = Resources.LoadAll<GameObject>("Food");
        objectPooler.PoolingNewObjects(objectToPool[0], 7);
    }
}