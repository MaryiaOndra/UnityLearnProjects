﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 20f;
    public float xRange= 15f;
    public GameObject projectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3( -xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput *  Time.deltaTime * speed);

        // make projectile fly
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch the projectile from the player
            Instantiate( projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
