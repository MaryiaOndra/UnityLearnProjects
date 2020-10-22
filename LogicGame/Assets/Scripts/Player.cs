using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent hit;
    [SerializeField] private float timeToDie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Block block)) 
        {
            Debug.Log(collision.collider.gameObject.name);
            hit?.Invoke();
            Destroy(gameObject, timeToDie);
        }        
    }
}
