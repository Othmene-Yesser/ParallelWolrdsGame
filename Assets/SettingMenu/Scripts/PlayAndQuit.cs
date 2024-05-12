using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAndQuit : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void BackToMainMenu()
    {
        gameManager.SavePlayerData();
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void QuitInRun()
    {
        gameManager.SavePlayerData();
        Application.Quit();
    }
}
