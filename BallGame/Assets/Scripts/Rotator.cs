using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rtX = 15f; 
    private float rtY = 30f; 
    private float rtZ = 45f; 

    void Update()
    {
        transform.Rotate(new Vector3(rtX, rtY, rtZ) * Time.deltaTime);
    }
}
