using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpdate : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerControls playerControls;
    private float updateSpeedAmount = 0.1f; 

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.RemoveFromCentralLocation(gameObject.transform.position);
            gameObject.SetActive(false);
            playerControls.playerSpeed += updateSpeedAmount;
        }
    }
}
