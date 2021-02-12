using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeChaseState : RangeState
{
    public override void Enter()
    {
        rangeEnemy.UpdateGameState("Chase");
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
        if (Vector3.Distance(transform.position, player.transform.position) <= rangeEnemy.attackRange)
        {
            stateMachine.ChangeState<RangeAttackState>();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > rangeEnemy.aggroRange)
        {
            stateMachine.ChangeState<RangeIdleState>();
        }
    }

    void LookAtPlayer()
    {

    }

    void ChasePlayer()
    {

    }
}
