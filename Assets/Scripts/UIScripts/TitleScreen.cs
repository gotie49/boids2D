using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public Transition transition;
    public AudioSource audioSource;
    Coroutine StartFade;
    
    public void StartGame()
    {
        StartFade = StartCoroutine(TitleAudio.StartFade(audioSource,0.5f, 0));
        transition.FadeToScene("MainGame");
        Debug.Log("get started bro");

    }
    public void QuitGame()
    {
        Debug.Log("get quit");
        Application.Quit();
    }
}
