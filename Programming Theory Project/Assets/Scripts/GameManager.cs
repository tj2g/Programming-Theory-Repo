using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float multiplier;
    private GameObject playerObject;

    public void Awake()
    {
        multiplier = 0.05f;
    }
    public void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    public void UpdatePlayer(float points)
    {
        Vector3 scale = playerObject.transform.localScale;
        scale.x += points;
        scale.y += points;
        scale.z += points;
        playerObject.transform.localScale = scale;
    }

    public IEnumerator SpawnWait(float seconds, GameObject spawnedObject)
    {
        yield return new WaitForSeconds(seconds);
        GameObject food = Instantiate(spawnedObject);
    }
}
