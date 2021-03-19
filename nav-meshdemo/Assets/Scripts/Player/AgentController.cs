using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject particlesPrefab;

    NavMeshAgent agent;
    float linkMoveProgress;
    GameObject particleObj;
    bool isNewPoint;

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
            }
        }

        if (isNewPoint 
            && agent.pathStatus == NavMeshPathStatus.PathComplete
            && particleObj == null)
        {
            particleObj = Instantiate(particlesPrefab, agent.destination, Quaternion.identity);
            isNewPoint = false;
        }

        if (!agent.hasPath && !agent.pathPending && particleObj)
        {
            Debug.Log("Destroy particle");
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
