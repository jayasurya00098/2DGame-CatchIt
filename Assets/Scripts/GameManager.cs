using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] eggImages;
    public GameObject gameOverScreen;

    bool isPaused = false;

    bool isGameOver = false;
    public bool IsGameOver
    {
        get { return isGameOver; }
    }

    int score;
    public Text scoreText;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score : " + score;
        }
    } 

    int life;

    public void ReduceLife()
    {
        if(life > 0)
        {
            life--;
            eggImages[life].SetActive(false);
        }

        if(life == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {

        if (PlayerPrefs.HasKey("HIGHSCORE"))
        {
            if(PlayerPrefs.GetInt("HIGHSCORE") < score)
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
        Debug.Log("Game Over");
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        life = 3;

        isPaused = false;
        Time.timeScale = 1;
    }

    public void Reload()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
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
}
