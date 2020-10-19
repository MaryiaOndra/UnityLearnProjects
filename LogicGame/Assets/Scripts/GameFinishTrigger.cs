using UnityEngine;

public class GameFinishTrigger : MonoBehaviour
{
    private EndPoint[] points;

    private void OnEnable()
    {
        points = gameObject.GetComponentsInChildren<EndPoint>();

        foreach (var point in points)
        {
            point.Reached += OnEndPointReached;
        }
    }

    private void OnDisable()
    {
        foreach (var point in points)
        {
            point.Reached -= OnEndPointReached;
        }
    }

    private void OnEndPointReached() 
    {
        foreach (var point in points)
        {
            if (point.IsReached == false) 
            {
                return;
            }
        }

        Debug.Log("Finish!");
    }
}

