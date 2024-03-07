using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public ObstacleMove obstacle;
    public BoostObstacle boostObstacle;
    public GameObject popup;
    public int currentWaveCount;
    public Flock[] flocks;
    const float timeBetweenWaveSpawns = 0.2f;
    const float timeBetweenWaveSpawnsBoost = 5;
    float nextSpawnTime = 0.2f;
    float nextSpawnTimeBoost = 10;
    int killCountNextSpawn;

    void Update()
    {
        if(Time.time > nextSpawnTimeBoost && currentWaveCount >1)
        {
            nextSpawnTimeBoost = Time.time + timeBetweenWaveSpawnsBoost;
            Instantiate(boostObstacle,Random.insideUnitCircle*16,Quaternion.identity);
        }
        
        if(Time.time > nextSpawnTime && currentWaveCount < flocks.Length && obstacle.killCount >= killCountNextSpawn)
        {
            nextSpawnTime = Time.time + timeBetweenWaveSpawns;
            currentWaveCount++;
            killCountNextSpawn += flocks[currentWaveCount-1].startingCount/2;
            Flock newFlock = Instantiate(flocks[currentWaveCount-1],Vector3.zero,Quaternion.identity);
            newFlock.name = "Flock" + currentWaveCount;
            if(currentWaveCount>1)
            {
                gameManager.currentTime += 30;
                Instantiate(popup,obstacle.transform.position,Quaternion.identity);
            }
        }           
    }
}