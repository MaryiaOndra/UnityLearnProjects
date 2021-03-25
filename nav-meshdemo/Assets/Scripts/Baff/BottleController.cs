using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    [SerializeField]
    GameObject healthBottle; 

    Waypoint[] waypoints;
    GameObject activeBottle;

    private void Awake()
    {
        waypoints = FindObjectsOfType<Waypoint>();     
    }

    public GameObject Appear() 
    {
        if (activeBottle == null)
        {
            Vector3 _bottlePos = waypoints[Random.Range(0, waypoints.Length)].transform.position;
            activeBottle = Instantiate(healthBottle, _bottlePos, Quaternion.identity);
        }

        return activeBottle;
    }

    public void DestroyBottle() 
    {
        Destroy(activeBottle);
    }

}
