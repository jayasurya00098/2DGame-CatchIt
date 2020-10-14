using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            highScoreText.text = "Highscore : " + PlayerPrefs.GetInt("HIGHSCORE");
        }

        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
