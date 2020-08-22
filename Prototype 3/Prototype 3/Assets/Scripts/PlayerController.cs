using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameCanStart = false; 
    private Animator playerAnim;
    private Rigidbody playerRb;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public Vector3 jumpForce;
    public float gravityModifier;
    private int jumps = 0;
    public bool gameOver = false;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool isDashing = false;
    public float score;
    private float scoreMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        score = 0;
        scoreMultiplier = 1.0f;
        
       
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameCanStart && transform.position.x < 0)
        {
            
            transform.Translate(Vector3.right * 2.5f * Time.deltaTime, Space.World);
        }

        else if (!gameCanStart && transform.position.x >= 0)
        {
            gameCanStart = true;
            dirtParticle.Play();
        }

        else
        {
            playerAnim.SetFloat("Speed_f", 1.0f);

            Debug.Log($"Score is: {score}");

            if (!gameOver)
            {
                score = score + (scoreMultiplier * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && jumps < 2 && !gameOver)

            {
                if (jumps == 1)
                {
                    playerRb.Sleep();
                }

                playerAnim.SetTrigger("Jump_trig");
                playerRb.AddForce(jumpForce, ForceMode.Impulse);
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound);
                jumps++;
            }

            if (jumps == 0)
            {

                if (Input.GetKey(KeyCode.LeftShift) && !gameOver)
                {
                    isDashing = true;
                    playerAnim.speed = 1.5f;
                    scoreMultiplier = 2.0f;
                }

                else
                {
                    isDashing = false;
                    playerAnim.speed = 1.0f;
                    scoreMultiplier = 1.0f;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (gameCanStart)
        {
            if (other.gameObject.CompareTag("Ground") && !gameOver)
            {
                jumps = 0;
                dirtParticle.Play();
                isDashing = false;
                playerAnim.speed = 1.0f;
            }

            else if (other.gameObject.CompareTag("Obstacle"))
            {
                explosionParticle.Play();
                dirtParticle.Stop();
                playerAudio.PlayOneShot(crashSound, 0.5f);
                Debug.Log("Game Over!");
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                gameOver = true;
                isDashing = false;
            }
        }
    }
}

