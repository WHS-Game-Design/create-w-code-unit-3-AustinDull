using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(speed * Vector3.left * Time.deltaTime);
    }
}
