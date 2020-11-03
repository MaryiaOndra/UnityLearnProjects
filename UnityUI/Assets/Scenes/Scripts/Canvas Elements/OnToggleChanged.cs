using UnityEngine;

public class OnToggleChanged : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    public void OnToggle(bool toggleOn) 
    {
        _text.SetActive(toggleOn);    
    }
}
