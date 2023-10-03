using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    public GameManager gameManager;
    private PlayerControls playerControls;
    public float points = 1;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControls = GameObject.Find("Player").GetComponent<PlayerControls>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.RemoveFromCentralLocation(transform.position);
            gameObject.SetActive(false);
            UpdatePlayer(points);
        }
    }

    public void UpdatePlayer(float points)
    {
        float makeBigger = (points * gameManager.multiplier * gameManager.level);
        playerControls.transform.localScale += new Vector3(makeBigger, makeBigger, makeBigger);
        Vector3 playerPosition = playerControls.transform.position;
        playerPosition.y += (makeBigger / 2);
        playerControls.transform.position = playerPosition;
    }
}
