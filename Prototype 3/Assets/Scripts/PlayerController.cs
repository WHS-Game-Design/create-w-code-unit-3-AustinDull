using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRB;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier = 9.8f;

    private bool grounded = true;

    public float speed;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            PlayerRB.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
