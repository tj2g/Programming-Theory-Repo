using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject player;

    public void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
    }

    public void LateUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        float playerYScale = player.transform.localScale.y;
        Vector3 cameraOffsetRelativeToPlayer = new Vector3(0, (10 * playerYScale), 0);
        mainCamera.transform.position = transform.position + cameraOffsetRelativeToPlayer;
    }
}
