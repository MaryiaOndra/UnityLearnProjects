using UnityEngine;
using UnityEngine.Events;

public class EndPoint : MonoBehaviour
{
    [SerializeField] UnityEvent reached;
    public bool IsReached { get; private set; }

    public event UnityAction Reached 
    {
        add => reached?.AddListener(value);
        remove => reached?.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached)
        {
            return;
        }

        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsReached = true;
            reached.Invoke();
        }
    }
}
