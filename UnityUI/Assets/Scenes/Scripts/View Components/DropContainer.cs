using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DropContainer : MonoBehaviour
{
    [SerializeField] private Transform _container;

    public Transform Container => _container;
}
