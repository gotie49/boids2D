using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public Transition transition;
    public void StartGame()
    {
        transition.FadeToScene("MainGame");
        Debug.Log("get started bro");

    }
    public void QuitGame()
    {
        Debug.Log("get quit");
        Application.Quit();
    }
}
