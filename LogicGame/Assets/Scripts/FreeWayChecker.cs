using UnityEngine;

public class FreeWayChecker : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] ContactFilter2D filter;
    [SerializeField] float speed;

    private readonly RaycastHit2D[] results = new RaycastHit2D[1];
    private float distance = 10.0f;

    private void FixedUpdate()
    {
        var collisionCount = playerRigidbody.Cast(transform.right, filter, results, distance );

        if (collisionCount == 0)
        {
            playerRigidbody.velocity = transform.right * speed;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
}
