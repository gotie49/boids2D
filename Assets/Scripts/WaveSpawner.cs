using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gameManager;
    public ObstacleMove obstacle;
    public BoostObstacle boostObstacle;
    public GameObject popup;
    public int currentWaveCount;
    public Flock[] flocks;
    FlockAgent[] allAgents;
    public int objectLimit = 500;
    const float timeBetweenWaveSpawns = 0.2f;
    const float timeBetweenWaveSpawnsBoost = 9;
    float nextSpawnTime = 0.2f;
    float nextSpawnTimeBoost = 10;
    int killCountNextSpawn;

    void Update()
    {
        FlockAgent[] allAgents = FindObjectsOfType<FlockAgent>();
        
        if(allAgents.Length<objectLimit)
        {
            if(Time.time > nextSpawnTimeBoost && currentWaveCount >1)
            {
                nextSpawnTimeBoost = Time.time + timeBetweenWaveSpawnsBoost;
                Instantiate(boostObstacle,Random.insideUnitCircle*25,Quaternion.identity);
            }
            
            if(Time.time > nextSpawnTime && currentWaveCount < flocks.Length-1 && obstacle.killCount >= killCountNextSpawn)
            {
                nextSpawnTime = Time.time + timeBetweenWaveSpawns;
                currentWaveCount++;
                killCountNextSpawn += flocks[currentWaveCount-1].startingCount/2;
                Flock newFlock = Instantiate(flocks[currentWaveCount-1],Vector3.zero,Quaternion.identity);
                newFlock.name = "Flock" + currentWaveCount;
                if(currentWaveCount>1)
                {
                    gameManager.currentTime += 10;
                    Instantiate(popup,obstacle.transform.position,Quaternion.identity);
                }
            }
            
        }
    }
    void Start()
    {
        InvokeRepeating("EndlessWave",40f, 7f);
    }
    void EndlessWave()
    {   
        FlockAgent[] allAgents = FindObjectsOfType<FlockAgent>();
        Debug.Log(allAgents.Length);
        if(allAgents.Length<objectLimit)
        {
            Instantiate(flocks[flocks.Length-1],Vector3.zero,Quaternion.identity);
        }
    }
}