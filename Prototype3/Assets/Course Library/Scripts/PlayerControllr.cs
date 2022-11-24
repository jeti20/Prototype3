using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllr : MonoBehaviour
{
    //public GameObject player;
    //public float horizontalInput;
    //public float verticallInput;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    private Rigidbody playerRb;
    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifer;
    [SerializeField] bool isOnTheGround;
    public bool gameOver = false;
    public bool doubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifer;
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && gameOver == false) // lub gameOVer != true, lub po prostu !gameOver
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Add an instant force impulse to the rigidbody, using its mass.
            //Apply the impulse force instantly with a single function call. This mode depends on the mass of rigidbody so more force must be applied to push or twist higher-mass objects the same amount as lower-mass objects. 
            //This mode is useful for applying forces that happen instantly, such as forces from explosions or collisions. In this mode, the unit of the force parameter is applied to the rigidbody as mass*distance/time.
            isOnTheGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop(); //zaczymujemy particel system 
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJump = true;


        }

        else if (Input.GetKeyDown(KeyCode.Space) && gameOver == false && doubleJump == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Add an instant force impulse to the rigidbody, using its mass.
            //Apply the impulse force instantly with a single function call. This mode depends on the mass of rigidbody so more force must be applied to push or twist higher-mass objects the same amount as lower-mass objects. 
            //This mode is useful for applying forces that happen instantly, such as forces from explosions or collisions. In this mode, the unit of the force parameter is applied to the rigidbody as mass*distance/time.
            isOnTheGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop(); //zaczymujemy particel system 
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            doubleJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Graund"))
        {
            isOnTheGround = true;
            dirtParticle.Play(); //startujemy particle system
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop(); //zaczymujemy particel system 
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }
}
