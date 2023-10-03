using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] float m_PlayerSpeed = 0.1f;

    //Encapsulation
    public float playerSpeed
    {
        get { return m_PlayerSpeed; }
        set
        {
            if (value < 0.0f)
            {
                value *= -1;
            }
            m_PlayerSpeed = value;
        }
    }

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        PlayerMovement();
    }


    //Abstraction
    private void PlayerMovement()
    {
        float horizontalPress = Input.GetAxis("Horizontal");
        float verticalPress = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalPress * m_PlayerSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalPress * m_PlayerSpeed * Time.deltaTime);
    }
}
