using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    Image healthLineImg;

    PlayerBhv playerBhv;
    float healthChangeTime = 0.5f;

    private void Awake()
    {
        playerBhv = GetComponentInParent<PlayerBhv>();
        playerBhv.OnHealthChanged += HandleHealthChanged;
    }

    void HandleHealthChanged(float img)
    {
        StartCoroutine(ChangeHealthToImg(img));
    }

    private IEnumerator ChangeHealthToImg(float health)
    {
        float preChangeImg = healthLineImg.fillAmount;
        float img = health;
        float elapsed = 0f;

        while (elapsed < healthChangeTime)
        {
            elapsed += Time.deltaTime;
            healthLineImg.fillAmount = Mathf.Lerp(preChangeImg, img, elapsed / healthChangeTime);
            yield return null;
        }

        healthLineImg.fillAmount = img;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
