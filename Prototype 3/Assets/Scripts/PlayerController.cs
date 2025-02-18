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
    private Animator playerAnim;
    public bool grounded = true;

    public bool gameIsActive = true;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            PlayerRB.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
            grounded = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle") && gameIsActive!)
        {
            gameIsActive = false;
            Debug.Log("I just lost the game");
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

        
    }
}
