using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    [SerializeField] InputActionReference pauseInput;
    public static bool isPaused = false;
    public GameObject creditsText;
    public GameObject optionsText;

    void Awake()
    {
    pauseInput.action.performed += OnPauseInput;
    }
    void OnPauseInput(InputAction.CallbackContext ctx)
    {
        if(isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    private void OnDestroy()
    {
        pauseInput.action.performed -= OnPauseInput;
    }
    public void Resume()
    {   
        creditsText.SetActive(false);
        optionsText.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        creditsText.SetActive(false);
        optionsText.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
