using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Abilities/Place Logic/Single Target")]
public class AbilityPlaceLogicSingleTarget : AbilityPlaceLogic
{
    public override List<Unit> TryGerTargets(Vector2 screenpoint)
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(screenpoint.x, screenpoint.y, 1));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15))
        {
            if (hit.transform.GetComponent<Unit>())
            {
                return new List<Unit>() { hit.transform.GetComponent<Unit>() };
            }
        }

        return null;
    }
}
