using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManager;
    public float playerYScale;
    private Vector3 cameraOffsetRelativeToPlayer;

    private void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void LateUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        playerYScale = player.transform.localScale.y + (gameManager.level * 2);
        cameraOffsetRelativeToPlayer = new Vector3(0, (playerYScale), 0);
        transform.position = player.transform.position + cameraOffsetRelativeToPlayer;
    }
}
