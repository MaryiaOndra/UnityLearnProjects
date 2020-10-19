using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float jumpForce;
    public void OnPointerClick(PointerEventData eventData)
    {
        rigidbody.AddForce(Vector3.up * jumpForce);
    }
}
