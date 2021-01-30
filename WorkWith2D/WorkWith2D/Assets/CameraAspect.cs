using UnityEngine;

[ExecuteAlways]
public class CameraAspect : MonoBehaviour
{

    [SerializeField] float widthSize;

    Camera targetCamera;

    void OnEnable()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        CheckAndCorrect();
    }

    void CheckAndCorrect() 
    {
        float _cameraSize = widthSize / Screen.width * Screen.height;
        targetCamera.orthographicSize = _cameraSize;
    }
}
