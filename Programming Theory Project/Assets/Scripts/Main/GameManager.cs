using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float multiplier;
    public float level = 1;
    public bool readyToLevel = false;

    private List<Vector3> locations = new List<Vector3>();

    private GameObject pausedPanel;
    private bool paused = false;

    private void Awake()
    {
        SceneCheck();
    }

    public void Start()
    {
        PlayerPrefs.SetInt("GameOn", 1);
        Initializer();
        LevelOneSetup();
    }

    private void Update()
    {
        PauseKeyChecker();
    }

    //Abstraction
    private void Initializer()
    {
        multiplier = 0.05f;
    }

    //Abstraction
    private void PauseKeyChecker()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pausing();
        }
        if (paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (paused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Pausing();
        }
    }

    //Abstraction
    private void Pausing()
    {
        if (!paused)
        {
            paused = true;
            pausedPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pausedPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //Abstraction
    private void SceneCheck()
    {
        int started = PlayerPrefs.GetInt("Started", 0);
        int gameOn = PlayerPrefs.GetInt("GameOn", 0);
        if (started == 0)
        {
            SceneManager.LoadScene(0);

        }
        else if (started == 1 && gameOn == 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            pausedPanel = GameObject.Find("PausePanel");
            pausedPanel.SetActive(false);
        }
    }

    //Abstraction
    private void LevelOneSetup()
    {
        if (level == 1)
        {
            GameObject[] objectToPool = Resources.LoadAll<GameObject>("PoolHeaders");
            foreach (GameObject tempobj in objectToPool)
            {
                GameObject obj = (GameObject)Instantiate(tempobj);
                obj.name = obj.name.Replace("(Clone)", "");
                obj.AddComponent<ObjectPooler>();
                obj.AddComponent<SpawnManager>();
            }
        }
    }

    public Vector3 CentralLocationCalculator(Vector3 location, float scale)
    {
        if (locations == null)
        {
            locations.Add(location);
        } 
        else
        {
            for (int x = 0; x < locations.Count; x++)
            {
                float tempDistance = Vector3.Distance(locations[x], location);
                if (tempDistance < scale)
                {
                    scale *= -1;
                    location.x -= scale;
                    location.z -= scale;
                }
            }
            locations.Add(location);
        }
        return location;
    }

    public void RemoveFromCentralLocation(Vector3 location)
    {
        locations.Remove(location);
    }
}