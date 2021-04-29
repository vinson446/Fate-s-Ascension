using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeIdleState : MeleeState
{
    public override void Enter()
    {
        meleeEnemy.UpdateGameState("Idle");
        animator.CrossFadeInFixedTime("Idle", 0.2f);
    }

    public override void Tick()
    {
        CheckAggroRange();
    }

    public override void Exit()
    {

    }

    void CheckAggroRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= meleeEnemy.attackRange)
        {
            stateMachine.ChangeState<MeleeAttackState>();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < meleeEnemy.aggroRange)
        {
            stateMachine.ChangeState<MeleeChaseState>();
        }
    }
}
