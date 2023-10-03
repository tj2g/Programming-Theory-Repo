using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject[] walls;
    private float scale;
    private Vector3 wallScale;
    public float updateNumber;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && gameManager.readyToLevel)
        {
            updateNumber = gameManager.level * 4;
            Debug.Log(updateNumber);
            //float updateNumber = gameManager.level * 4;
            scale = (((updateNumber) / 10) * 2);
            Debug.Log(updateNumber);
            wallScale = new Vector3(scale, 1, scale);
            foreach (GameObject wall in walls)
            {
                wall.transform.localScale = wallScale;
                Vector3 wallPos = wall.transform.position;
                wall.transform.position = WallCalculation(wallPos);
            }
            gameManager.readyToLevel = false;
            gameManager.Start();
        }
    }

    private Vector3 WallCalculation(Vector3 sizeUpdate)
    {
        //float updateNumber = gameManager.level * 4;
        float[] position = { sizeUpdate.x, sizeUpdate.y, sizeUpdate.z };

        for (int x = 0; x < position.Length; x++)
        {
            if (position[x] < 0)
            {
                position[x] = (-1 * updateNumber);
            }
            else if (position[x] > 0)
            {
                position[x] = updateNumber;
            }
        }

        sizeUpdate = new Vector3(position[0], position[1], position[2]);

        return sizeUpdate;
    }
}
