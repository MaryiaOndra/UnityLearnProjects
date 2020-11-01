using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _targetLastPosition;
    private Tweener _tween;

    void Start()
    {
        _tween = transform.DOMove(_target.position, 2).SetAutoKill(false);
        _targetLastPosition = _target.position;
    }

    void Update()
    {
        if (_targetLastPosition != _target.position)
        {
            _tween.ChangeEndValue(_target.position, true).Restart();
            _targetLastPosition = _target.position;
        }
    }
}
