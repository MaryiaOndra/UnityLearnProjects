using TMPro;
using UnityEngine;

public class ToText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Dropdown _dropdown;

    public void ChangeText(int dropdownInt) 
    {
        _text.text = _dropdown.options[dropdownInt].text;
    }
}
