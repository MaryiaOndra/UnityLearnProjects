using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public float jumpForce;
    public float gravityModifier;
    public float walkSpeed = 5f;

    public bool isRunning = false;
    public bool isOnGround = true;
    public bool isGameOver = false;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;


    //private int currentJump = 0;
    //private const int maxJumps = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            transform.Translate(Vector3.forward * walkSpeed);
            dirtParticle.Stop();
        }

        if (Input.GetKey(KeyCode.Space) && !isGameOver &&(isOnGround /*|| maxJumps > currentJump)*/))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            //make player jump when you press space
            playerAnim.SetTrigger("Jump_trig");
            //currentJump++;      

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Start"))
        {
            isRunning = true;
            playerAnim.SetFloat("Speed_f", 1f);

            //GameObject startObject = GameObject.FindGameObjectWithTag("Start");
            Destroy(GameObject.FindGameObjectWithTag("Start"));

            explosionParticle.Stop();
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            //currentJump = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            print("IS OVER!");

            //add death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
