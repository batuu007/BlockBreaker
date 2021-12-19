using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void ReturnStartMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().RestartToScore();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
