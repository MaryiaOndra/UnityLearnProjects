using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField] Transform spherePoint;
    [SerializeField] GameObject spherePrefab;
    [SerializeField] Transform verticalTr;
    [SerializeField] float speed = 4;
    [SerializeField] float jumpForce;
    [SerializeField] float shootForce;
    [SerializeField] float rechargeTime;

    CharacterController chController;

    float verticalSpeed;
    float shootTimer;

    void Awake()
    {
        chController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X");
        float _mouseY = Input.GetAxis("Mouse Y") * -1;

        chController.transform.Rotate(Vector3.up, _mouseX);
        verticalTr.Rotate(Vector3.right, _mouseY, Space.Self);

        float _vertical = Input.GetAxis("Vertical");
        float _horizontal = Input.GetAxis("Horizontal");

        Vector3 _speedVector = transform.forward * _vertical * speed * Time.deltaTime + transform.right * _horizontal * speed * Time.deltaTime;

        verticalSpeed = chController.velocity.y;
        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        float _jumpAxis = Input.GetAxis("Jump");
        if (_jumpAxis > 0 && chController.isGrounded)
        {
            verticalSpeed = jumpForce;
        }

        _speedVector += transform.up * verticalSpeed * Time.deltaTime;
        
        chController.Move(_speedVector);

        if (shootTimer > 0 )
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0 )
            {
                shootTimer = 0;
            }
        }
        
        float _fireAxis = Input.GetAxis("Fire1");
        if (_fireAxis > 0 && IsRecharge )
        {
            Rigidbody _sphereRgBd = Instantiate(spherePrefab).GetComponent<Rigidbody>();
            _sphereRgBd.transform.position = spherePoint.position;
            _sphereRgBd.transform.rotation = spherePoint.rotation;

            _sphereRgBd.AddForce(_sphereRgBd.transform.forward * shootForce, ForceMode.Impulse);
            shootTimer = rechargeTime;
        }
    }

    bool IsRecharge => shootTimer > 0;
}
