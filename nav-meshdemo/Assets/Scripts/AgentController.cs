using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    NavMeshAgent agentNavMesh;
    float linkMoveProgress;

    private void Awake()
    {
        agentNavMesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit _raycastHit;

            if (Physics.Raycast(_ray, out _raycastHit))
            {
                agentNavMesh.SetDestination(_raycastHit.point);
            }
        }

        if (agentNavMesh.isOnOffMeshLink)
        {
            linkMoveProgress += Time.deltaTime;

            Vector3 _newPos = Vector3.Lerp(agentNavMesh.currentOffMeshLinkData.startPos, agentNavMesh.currentOffMeshLinkData.endPos, linkMoveProgress);
            _newPos.y = transform.position.y;

            transform.position = _newPos;

            if (linkMoveProgress >= 1f)
            {
                linkMoveProgress = 0;
                agentNavMesh.CompleteOffMeshLink();
            }
        }
    }

}
