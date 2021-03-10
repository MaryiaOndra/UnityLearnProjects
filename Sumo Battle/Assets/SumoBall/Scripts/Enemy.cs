using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    GameObject player;
    Rigidbody enemyRb;
    

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        enemyRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
