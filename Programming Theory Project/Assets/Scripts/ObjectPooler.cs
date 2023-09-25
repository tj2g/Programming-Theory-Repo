using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    private List<GameObject> pooledObjects;

    public void Awake()
    {
        SharedInstance = this;
    }

    public void PoolingNewObjects(GameObject objectBeingPooled, int amountOfPool)
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountOfPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectBeingPooled);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
