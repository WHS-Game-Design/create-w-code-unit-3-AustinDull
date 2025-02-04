using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPostition = new Vector3(30, 0, 0);
    
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    
    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPostition, obstaclePrefab.transform.rotation);
    }
}
