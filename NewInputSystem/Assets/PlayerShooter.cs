using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (PlayerInput))]
public class PlayerShooter : MonoBehaviour
{
    public void OnShoot(InputAction.CallbackContext context) 
    {
        Debug.Log("FIRE!");
    }
}
