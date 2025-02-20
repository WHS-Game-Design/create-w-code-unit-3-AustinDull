using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Vector3 spawnPostition = new Vector3(30, 2, 2);
    private PlayerController playerControllerScript;

    private float startDelay = 1;
    private float repeatRate = 1.5f;

    void Start()
    {

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    
    void SpawnObstacle()
    {
        if(playerControllerScript.gameIsActive == true)
        {
            Instantiate(obstaclePrefab, spawnPostition, obstaclePrefab.transform.rotation);
        }
        
    }
}
