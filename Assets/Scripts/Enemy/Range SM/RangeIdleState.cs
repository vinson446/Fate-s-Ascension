using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIdleState : RangeState
{
    public override void Enter()
    {
        rangeEnemy.UpdateGameState("Idle");
        animator.CrossFadeInFixedTime("Idle", 0.2f);
    }

    public override void Tick()
    {
        CheckRanges();
    }

    public override void Exit()
    {

    }

    void CheckRanges()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= rangeEnemy.attackRange)
        {
            stateMachine.ChangeState<RangeAttackState>();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < rangeEnemy.aggroRange)
        {
            stateMachine.ChangeState<RangeChaseState>();
        }
    }
}
