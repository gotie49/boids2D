using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameIsOver = false;
    public GameObject GameOverObject;
    public float currentTime;
    public float startingTime = 100;
    bool timerActive = true;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
        {
        if(timerActive == true)
        {
            currentTime -= Time.deltaTime;
        }
        if(currentTime <= 0)
        {
            timerActive = false;
            Start();
            GameOver();
        }
    }
    public void GameOver()
    {
        if(gameIsOver == false)
        {
        gameIsOver = true;
        GameOverObject.SetActive(true);
        }
    }
    public void StartTimer()
    {
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("MainGame",LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
