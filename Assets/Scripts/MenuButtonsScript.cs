using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{
    public void GoToTheMenu()
    {
        SceneManager.LoadScene("SimpleMenu");
        Time.timeScale = 1f;
        Debug.Log("Button Pressed");
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene("DevoulScene");
        Time.timeScale = 1f;
        Debug.Log("Button Pressed");
    }

    public void ClassicSnakeGame()
    {
        SceneManager.LoadScene("ClassicSnakeGame");
        Time.timeScale = 1f;
        Debug.Log("Button Pressed");
    }

    public void ShowHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
        Time.timeScale = 1f;
        Debug.Log("Button Pressed");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
