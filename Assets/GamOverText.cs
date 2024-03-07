using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamOverText : MonoBehaviour
{
    public WaveSpawner spawner;
    public ObstacleMove obstacle;
    private TMP_Text gameoverText;
    int survivedWaves;
    private void Awake()
    {
        gameoverText = GetComponent<TMP_Text>();
    }
    void Update()
    {     
        survivedWaves =spawner.currentWaveCount-1;
        gameoverText.text = "You reached a score of " + obstacle.killCount + " and survived " + survivedWaves + " Waves.";
    }
}
