using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDeathState : RangeState
{
    public override void Enter()
    {
        Die();
    }

    void Die()
    {
        animator.CrossFadeInFixedTime("Death", 0.2f);
    }
}
