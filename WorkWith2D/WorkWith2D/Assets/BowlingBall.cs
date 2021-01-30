using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    void Update()
    {
        
    }

    public void OnBallClicked() 
    {
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        //rigidbody2D.AddForce(Vector2.right * 50, ForceMode2D.Impulse);
        rigidbody2D.velocity = transform.right * 10;
    }
}
