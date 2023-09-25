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

    public void SpawnFood(int seconds)
    {
        StartCoroutine(SpawnWait(seconds));
    }

    private IEnumerator SpawnWait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        int randomX = Random.Range(-99, 99);
        int randomZ = Random.Range(-99, 99);

        Vector3 spawnPos = new Vector3((randomX / 100f), 0.03f, (randomZ / 100f));

        GameObject foodObject = ObjectPooler.SharedInstance.GetPooledObject();
        if (foodObject != null)
        {
            foodObject.SetActive(true);
            foodObject.transform.position = spawnPos;
        }
    }
}