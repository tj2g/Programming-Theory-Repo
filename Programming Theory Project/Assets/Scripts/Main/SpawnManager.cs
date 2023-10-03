using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Setting up script global variables
    private GameManager gameManager;
    private ObjectPooler objectPooler;
    private SpawnBehavior spawnBehavior;
    private GameObject spawnManagerGamingObject;
    private float scale;
    [SerializeField] private bool startRepeat = false;
    private int randomSeconds;

    private void Awake()
    {
        // Start of creating the pool of objects based on criteria from the Resources/PoolHeader Objects
        GameObject[] objectToPool = Resources.LoadAll<GameObject>("Food");
        foreach (GameObject currentGameObj in objectToPool)
        {
            if (currentGameObj.name == gameObject.name)
            {
                objectPooler = GameObject.Find(currentGameObj.name).GetComponent<ObjectPooler>();
                spawnBehavior = GameObject.Find(currentGameObj.name).GetComponent<SpawnBehavior>();
                objectPooler.PoolingNewObjects(currentGameObj, spawnBehavior.poolAmount);
            }
        }
        //End of creating pooled objects
    }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scale = 0.05f;
        InvokeSpawning();
    }

    private void Update()
    {
        if (gameManager.readyToLevel == true && startRepeat == false)
        {
            InvokeSpawning();
            startRepeat = true;
        }
        
        if (gameManager.readyToLevel == false && startRepeat == true)
        {
            scale = (10 * gameManager.level * 0.05f) / 2;
            InvokeSpawning();
            startRepeat = false;
        }
    }

    //Abstraction
    private void InvokeSpawning()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        int startSeconds = spawnBehavior.startSeconds;
        int endSeconds = spawnBehavior.endSeconds;
        randomSeconds = Random.Range(startSeconds, endSeconds);
        int count = spawnBehavior.spawnAmount;
        for (int x = 0; x < count; x++)
        {
            yield return new WaitForSeconds(randomSeconds);
            spawnManagerGamingObject = objectPooler.GetPooledObject();
            if (spawnManagerGamingObject == null)
            {
                count++;
                randomSeconds = Random.Range(startSeconds, endSeconds);
            }
            else
            {
                SetSpawnSettings();
                randomSeconds += startSeconds;
            }
        }        
    }

    //Abstraction
    private void SetSpawnSettings()
    {
        Vector3 spawnPos = SetSpawnPosition();

        if (spawnManagerGamingObject != null)
        {
            spawnManagerGamingObject.transform.position = spawnPos;
            spawnManagerGamingObject.transform.localScale = new Vector3(scale, scale, scale);
            spawnManagerGamingObject.SetActive(true);
        }
    }

    //Abstraction
    private Vector3 SetSpawnPosition()
    {
        // Setting up decimal value (0.xx) for the x and z range whole number
        int range = 99;
        float randomXDecimal = (Random.Range(-range, range) / 100f);
        float randomZDecimal = (Random.Range(-range, range) / 100f);

        //  Setting up the spawn range within 80% of the total box range, can change percentage later, the 0.xx range won't be that big a difference added in
        float randomX = (Random.Range(0, 0) * 0.8f) + randomXDecimal;
        float randomZ = (Random.Range(0, 0) * 0.8f) + randomZDecimal;

        Vector3 spawnPos = new Vector3(randomX, scale, randomZ);

        spawnPos = gameManager.CentralLocationCalculator(spawnPos, scale);

        return spawnPos;
    }
}
