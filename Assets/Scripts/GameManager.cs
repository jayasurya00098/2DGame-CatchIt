using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;

    public GameObject[] eggImages;
    public GameObject gameOverScreen;

    public Text scoreText;

    int life;

    //used for Pause and Play.
    bool isPaused = false;

    //used for Game Over.
    bool isGameOver = false;
    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    //used for Score Update.
    int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score : " + score;
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;

        score = 0;
        life = 3;

        isPaused = false;
        Time.timeScale = 1;
    }

    //Used to Reload The Game Scene.
    public void Reload()
    {
        SceneManager.LoadScene(1);
    }

    //Used to Load Menu Scene.
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        ///Move to Pause Button.
        //Escape key is pressed to pause the Game.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                isPaused = true;
                Time.timeScale = 0;
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1;
            }
        }
    }

    public void ReduceLife()
    {
        if (life > 0)
        {
            life--;
            eggImages[life].SetActive(false);
        }

        //when life becomes Zero Game Over is called
        if (life == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            if (PlayerPrefs.GetInt("HIGHSCORE") < score)
            {
                PlayerPrefs.SetInt("HIGHSCORE", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }

        isGameOver = true;
        gameOverScreen.SetActive(true);

        audioManager.PlayClip(audioManager.gameOverClip);

        Debug.Log("Game Over");
    }
}
