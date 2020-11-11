using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityPlaceLogic : ScriptableObject
{
    public abstract List<Unit> TryGerTargets(Vector2 screenpoint);
}
