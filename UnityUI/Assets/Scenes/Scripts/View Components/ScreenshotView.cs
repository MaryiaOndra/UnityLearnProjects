using UnityEngine.UI;
using UnityEngine;

public class ScreenshotView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _date;


    public void Render(Screenshot screenshot)
    {
        _image.sprite = screenshot.Image;
        _date.text = screenshot.CreationTime.ToString();
    }
}
