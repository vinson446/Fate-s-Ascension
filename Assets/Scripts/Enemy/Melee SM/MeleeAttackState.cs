using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MeleeState
{
    public override void Enter()
    {
        meleeEnemy.UpdateGameState("Attack");
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
        if (Vector3.Distance(transform.position, player.transform.position) > meleeEnemy.attackRange && 
            Vector3.Distance(transform.position, player.transform.position) <= meleeEnemy.aggroRange)
        {
            stateMachine.ChangeState<MeleeChaseState>();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > meleeEnemy.aggroRange)
        {
            stateMachine.ChangeState<MeleeIdleState>();
        }
    }

    void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= meleeEnemy.attackRange)
        {
            meleeEnemy.Attack();
        }
    }
}
