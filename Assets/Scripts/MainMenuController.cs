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
        //Updates HighScore Everytime when the Menu Scene is Loaded.
        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            highScoreText.text = "Highscore : " + PlayerPrefs.GetInt("HIGHSCORE");
        }

        //Set TimeScale back to 1 if the Menu is loaded during Pause Game.
        Time.timeScale = 1;
    }

    //Used to Open Game Scene.
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Used to Exit the Game.
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
        #else
        Application.Quit();
        #endif
    }

}
