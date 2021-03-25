using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject particlesPrefab;

    NavMeshAgent agent;
    float linkMoveProgress;
    GameObject particleObj;
    GameObject secParticleObj;
    GameObject moveParticleObj;
    bool isNewPoint;

    List<Vector3> points = new List<Vector3>();

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _raycastHit;

            if (Physics.Raycast(_ray, out _raycastHit))
            {
                agent.SetDestination(_raycastHit.point);
                isNewPoint = true;
                points.Add(_raycastHit.point);
            }
        }

        if (isNewPoint 
            && agent.pathStatus == NavMeshPathStatus.PathComplete
            && particleObj == null)
        {
            particleObj = Instantiate(particlesPrefab, agent.destination, Quaternion.identity);
            isNewPoint = false;
            if (secParticleObj)
                Destroy(secParticleObj);
        }
        else if (isNewPoint && points.Count >= 1)
        {
            Destroy(particleObj);
            secParticleObj = Instantiate(particlesPrefab, agent.destination, Quaternion.identity);
            points.RemoveRange(0, points.Count - 1);
        }


        if (!agent.hasPath && !agent.pathPending && particleObj)
        {
            Destroy(particleObj);
            particleObj = null;
        }

        if (agent.isOnOffMeshLink)
        {
            linkMoveProgress += Time.deltaTime;

            Vector3 _newPos = Vector3.Lerp(agent.currentOffMeshLinkData.startPos, agent.currentOffMeshLinkData.endPos, linkMoveProgress);
            _newPos.y = transform.position.y;

            transform.position = _newPos;


            if (linkMoveProgress >= 1f)
            {
                linkMoveProgress = 0;
                agent.CompleteOffMeshLink();
            }
        }

    }
}
