using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject completeLevelUI;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private string tagName = "PickUp";
    private static int count;
    private int countPickUpObjects;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        countPickUpObjects = GameObject.FindGameObjectsWithTag(tagName).Length;
        completeLevelUI.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 momementVector = movementValue.Get<Vector2>();
        movementX = momementVector.x;
        movementY = momementVector.y;
    }

    void SetCountText()
    {
        countText.text = "COUNT: " + count.ToString();

        if (count >= countPickUpObjects)
        {
            completeLevelUI.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}
