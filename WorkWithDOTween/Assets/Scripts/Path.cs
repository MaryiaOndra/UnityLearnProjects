using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoint;
    void Start()
    {
        Tween tween = transform.DOPath(_waypoint, 5, PathType.CatmullRom).SetOptions(true).SetLookAt(0.05f);

        tween.SetEase(Ease.Linear).SetLoops(-1);
    }

}
