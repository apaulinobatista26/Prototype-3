using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle; 
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private int jumpCount = 0;
    public int maxJumps = 2;
    public bool dash = false;

    // Start is called before the first frame update
    void Start()
    {
            playerRb = GetComponent<Rigidbody>();
            playerAnim = GetComponent<Animator>();
            Physics.gravity *= gravityModifier;
            playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
           if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps && !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpCount++;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
             }

             if ( Input.GetKey(KeyCode.A))
             {
                dash = true;
             }

             else
             {
                dash = false;
             }
    }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Ground"))
         {
           isOnGround = true; 
           dirtParticle.Play();
           jumpCount = 0;
         }
         else if (collision.gameObject.CompareTag("Obstacle"))
         {
           Debug.Log("Game over!");
           gameOver = true;
           playerAnim.SetBool("Death_b", true);
           playerAnim.SetInteger("DeathType_int", 1);
           explosionParticle.Play();
           dirtParticle.Stop();
           playerAudio.PlayOneShot(crashSound, 1.0f);
         }
    }
}       
        
        