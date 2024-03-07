using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;
    public ObstacleMove obstacle;
    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    void Update(){
        scoreText.text = obstacle.killCount.ToString();
    }
}
