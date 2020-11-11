using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Actions/Damage")]
public class AbilityActionDamage : AbilityAction
{
    [SerializeField] private float _damage;
    public override void Action(Unit target)
    {      

    }
}

