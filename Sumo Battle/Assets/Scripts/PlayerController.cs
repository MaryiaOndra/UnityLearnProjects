using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody playerRb;
    GameObject focalPoint;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = FindObjectOfType<CameraRotator>().gameObject;
    }

    void FixedUpdate()
    {
        float _vertical = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * _vertical * speed);
    }
}
