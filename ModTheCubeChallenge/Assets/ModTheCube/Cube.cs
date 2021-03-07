using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    MeshRenderer renderer;
    Material material;
    Color matColor;

    float rotAngle;
    float rotAngle2;
    float rotSpeed;
    float scale;
    float timeLenght = 1; 

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
    }

    void Start()
    {
        rotAngle = Random.Range(-2.0f, 2.0f);
        rotAngle2 = Random.Range(-2.0f, 2.0f);
        rotSpeed = Random.Range(0f, 3f);
        scale = Random.Range(1f, 5f);

        transform.position = new Vector3(Random.Range(0, 5), Random.Range(0, 6), Random.Range (0, 5));
        transform.localScale = Vector3.one * scale;
        matColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    
    void Update()
    {
        transform.Rotate(rotSpeed * Time.deltaTime, rotAngle, rotAngle2 );
        material.color = Color.Lerp(Color.white, matColor, Mathf.PingPong(Time.time, timeLenght));
    }
}
