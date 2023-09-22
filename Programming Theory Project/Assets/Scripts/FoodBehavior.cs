using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    private SpawnManager spawnManager;
    private GameManager gameManager;
    private float points = 1;

    public void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        points *= gameManager.multiplier;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            gameManager.UpdatePlayer(points);
            //spawnManager.foodCount -= 1;
        }
    }
}
