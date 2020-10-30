using DG.Tweening;
using UnityEngine;

public class DoMove : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(new Vector3(0, 5, 0), 3).SetLoops(-1, LoopType.Yoyo).From();
    }
}
