using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{// spawning objetcs in intervals
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    float startDelay = 2;
    float repeatRate = 2;

    private PlayerControllr playerControllerScrip;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // wykonuje metode co 2 sekundy 2 sekundy po starce
        playerControllerScrip = GameObject.Find("Player").GetComponent<PlayerControllr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScrip.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacleIndex], spawnPosition, obstaclePrefab[0].transform.rotation);
        }
    }
}
