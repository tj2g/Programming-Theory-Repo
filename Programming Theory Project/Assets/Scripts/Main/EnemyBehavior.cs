using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Inheritance
public class EnemyBehavior : FoodBehavior
{
    private void OnCollisionEnter(Collision collision)
    {
        //Polymorphism
        points = -1;
        if (collision.gameObject.name == "Player")
        {
            gameManager.RemoveFromCentralLocation(gameObject.transform.position);
            gameObject.SetActive(false);
            UpdatePlayer(points);
        }
    }
}
