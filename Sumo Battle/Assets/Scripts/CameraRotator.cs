using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, _horizontal * rotationSpeed * Time.deltaTime);        
    }
}
