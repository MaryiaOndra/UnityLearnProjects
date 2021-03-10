using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float powerupSrenght;
    [SerializeField] GameObject powerupIndicator;

    Rigidbody playerRb;
    GameObject focalPoint;
    bool hasPowerup;
    

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = FindObjectOfType<CameraRotator>().gameObject;
    }

    private void Update()
    {
        float _vertical = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * _vertical * speed);
        powerupIndicator.transform.position = transform.position - new Vector3(0, 0.3f, 0);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody _enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 _impulseDir = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with " + collision.gameObject.name );

            _enemyRb.AddForce(_impulseDir * powerupSrenght, ForceMode.Impulse);

            StartCoroutine(PowerupCountdownRutine());
        }
    }

    IEnumerator PowerupCountdownRutine() 
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
