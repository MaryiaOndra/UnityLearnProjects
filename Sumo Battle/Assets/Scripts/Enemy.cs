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
    void FixedUpdate()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);
    }
}
