using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : RangeState
{
    public override void Enter()
    {
        rangeEnemy.UpdateGameState("Attack");
    }

    public override void Tick()
    {
        CheckRanges();

        Attack();
    }

    public override void Exit()
    {

    }

    void CheckRanges()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > rangeEnemy.attackRange &&
            Vector3.Distance(transform.position, player.transform.position) <= rangeEnemy.aggroRange)
        {
            stateMachine.ChangeState<RangeChaseState>();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > rangeEnemy.aggroRange)
        {
            stateMachine.ChangeState<RangeIdleState>();
        }
    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= rangeEnemy.attackRange)
        {
            rangeEnemy.Attack();
        }
    }
}
