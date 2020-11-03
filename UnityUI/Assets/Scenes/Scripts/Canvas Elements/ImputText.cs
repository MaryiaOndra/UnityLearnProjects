using TMPro;
using UnityEngine;

public class ImputText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ToText(string text) 
    {
        _text.text = text;    
    }
}
