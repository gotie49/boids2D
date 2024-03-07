using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    public GameManager gameManager;
    private TMP_Text timerText;
    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(gameManager.currentTime);
        timerText.text = string.Format("{0}:{1:00}",time.Minutes,time.Seconds);
    }
}

