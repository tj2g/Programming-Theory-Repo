using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    private void Update()
    {
        ExitKeyCheck();
        StartKeyCheck();
    }

    private void Awake()
    {
        PlayerPrefChecks();
    }


    //Abstraction
    public void StartGame()
    {
        StartingGame();
    }

    //Abstraction
    private void ExitKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X))
        {
            Exit();
        }
    }

    //Abstraction
    private void StartKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
    }

    //Abstraction
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    //Abstraction
    private void PlayerPrefChecks()
    {
        PlayerPrefs.SetInt("Started", 0);
        PlayerPrefs.SetInt("GameOn", 0);
    }

    //Abstraction
    private void StartingGame()
    {
        PlayerPrefs.SetInt("Started", 1);
        SceneManager.LoadScene(1);
    }
}
