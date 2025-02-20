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
    private AudioSource playerAudio;
    public bool grounded = true;
    public bool gameIsActive = true;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded && gameIsActive)
        {
            PlayerRB.AddForce(Vector3.up *jumpForce, ForceMode.Impulse);
            grounded = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {


        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            dirtParticle.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle") && gameIsActive)
        {
            gameIsActive = false;
            Debug.Log("I just lost the game");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
