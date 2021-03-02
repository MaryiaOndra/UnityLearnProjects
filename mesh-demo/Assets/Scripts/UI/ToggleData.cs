using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WallGenerator
{
    public class ToggleData : MonoBehaviour
    {
        [SerializeField] Turn turn;

        public Turn TurnState => turn;
    }
}
