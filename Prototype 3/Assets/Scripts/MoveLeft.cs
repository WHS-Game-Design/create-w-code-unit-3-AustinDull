using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float leftBound = -15f;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (playerControllerScript.gameIsActive == true)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
        if(transform.position.x < leftBound && CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
