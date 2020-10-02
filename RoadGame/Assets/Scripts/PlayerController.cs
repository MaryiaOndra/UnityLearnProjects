using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(10f, 50f)]
    public float speed = 15.5f;
    public GameObject animation;

    private float turnSpeed = 40;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        animation.SetActive(false);
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //Move the vehicle right and left
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        animation.SetActive(true);
    }
}
