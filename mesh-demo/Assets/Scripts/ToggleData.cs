using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleData : MonoBehaviour
{
    [SerializeField]  Turn turn;

    public Turn TurnState => turn;
}
