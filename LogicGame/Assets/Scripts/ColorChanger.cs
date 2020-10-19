 using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Color targetColor;

    public void ChangeColor()
    {
        renderer.color = targetColor;
    }
}
