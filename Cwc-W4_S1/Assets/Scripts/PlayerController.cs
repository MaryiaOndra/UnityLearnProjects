using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityModifier;

    private Animator playerAnim;
    public float walkSpeed = 5f;

    public bool isRunning = false;
    public bool isOnGround = true;
    public bool isGameOver = false;
    //private int currentJump = 0;
    //private const int maxJumps = 3;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = transform.position;

        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
        {
            transform.Translate(Vector3.forward * walkSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && !isGameOver &&(isOnGround /*|| maxJumps > currentJump)*/))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            //make player jump when you press space
            playerAnim.SetTrigger("Jump_trig");
            //currentJump++;           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            //currentJump = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            print("IS OVER!");

            //add death animation
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
        else if (collision.gameObject.CompareTag("Start"))
        {
            isRunning = true;
            playerAnim.SetFloat("Speed_f", 1f);
        }
    }
}
