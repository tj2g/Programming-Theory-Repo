using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float speed = 0.1f;

    public void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontalPress = Input.GetAxis("Horizontal");
        float verticalPress = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalPress * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalPress * speed * Time.deltaTime);
    }
}
