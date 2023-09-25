using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject playerObject;
    private SpawnManager spawnManager;
    public float multiplier;

    public void Start()
    {
        multiplier = 0.05f;
        playerObject = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        InvokeRepeating("InvokeRandomFoodSpawnRepeat", 5, 5);
    }

    public void UpdatePlayer(float points)
    {
        Vector3 scale = playerObject.transform.localScale;
        float makeBigger = (points * multiplier);
        Debug.Log(makeBigger);
        scale.x += makeBigger;
        scale.y += makeBigger;
        scale.z += makeBigger;
        playerObject.transform.localScale = scale;
    }

    private void InvokeRandomFoodSpawnRepeat()
    {
        int randomSpawnSeconds = Random.Range(3, 20);
        spawnManager.SpawnFood(randomSpawnSeconds);
    }
}
