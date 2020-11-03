using UnityEngine;

public class PushButton : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    public void OnButtonClicked() 
    {
        Destroy(_text);
    }
}
