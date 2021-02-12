using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeChaseState : MeleeState
{
    public override void Enter()
    {
        meleeEnemy.UpdateGameState("Chase");
    }

    public override void Tick()
    {
        CheckRanges();

        LookAtPlayer();
        ChasePlayer();
    }

    public override void Exit()
    {

    }

    void CheckRanges()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= meleeEnemy.attackRange)
        {
            stateMachine.ChangeState<MeleeAttackState>();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > meleeEnemy.aggroRange)
        {
            stateMachine.ChangeState<MeleeIdleState>();
        }
    }

    void LookAtPlayer()
    {

    }

    void ChasePlayer()
    {

    }
}
