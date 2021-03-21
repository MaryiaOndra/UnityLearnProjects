using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;

    float attackDistance = 3f;
    float chaseDistance = 7f;
    int waypointIndex;
    bool isChasing;

    PlayerMover player;
    NavMeshAgent agent;
    EnemyBhv enemyBhv;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMover>();
        enemyBhv = GetComponent<EnemyBhv>();
    }

    private void Start()
    {
        agent.SetDestination(waypoints[waypointIndex].position);
    }

    private void Update()
    {
        GoNextPoint();
        CheckForChasing();
    }

    void GoNextPoint() 
    {
        if (!agent.hasPath && !agent.pathPending && !isChasing)
        {
            waypointIndex = (int)Mathf.Repeat(waypointIndex + 1, waypoints.Count);
            agent.SetDestination(waypoints[waypointIndex].position);
        }
    }

    void CheckForChasing() 
    {
        Vector3 _targetPos = player.transform.position;
        float _attackOffcet = attackDistance * 0.5f;
        Vector3 _attackPos = new Vector3(_targetPos.x - _attackOffcet, _targetPos.y, _targetPos.z - _attackOffcet);
        float _distanceToTarget = Vector3.Distance(transform.position, _targetPos);

        if (_distanceToTarget < chaseDistance)
        {
            isChasing = true;
            agent.SetDestination(_attackPos);

            RotateTowardsTarget();
            CheckForAttack(_distanceToTarget);
        }
        else
        {
            isChasing = false;
        }
    }

    void RotateTowardsTarget() 
    {
        float _speed = 6.28f;
        float _singleStep = _speed * Time.deltaTime;
        Vector3 _targetDirection = player.transform.position - agent.transform.position;
        Vector3 _newDirection = Vector3.RotateTowards(agent.transform.forward, _targetDirection, _singleStep, float.PositiveInfinity);
        Debug.DrawRay(agent.transform.position, _newDirection, Color.red);
        agent.transform.rotation = Quaternion.LookRotation(_newDirection);
    }

    void CheckForAttack(float distanceToTarget)
    {
        if (distanceToTarget < attackDistance)
        {
            enemyBhv.Attack();
        }
    }

}
