using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBhv : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] List<Transform> waypoints;
    int waypointIndex;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        agent.SetDestination(waypoints[waypointIndex].position);
    }
    private void Update()
    {
        if (!agent.hasPath && !agent.pathPending)
        {
            waypointIndex = (int)Mathf.Repeat(waypointIndex +1, waypoints.Count);
            agent.SetDestination(waypoints[waypointIndex].position);
            
        }
    }

}
