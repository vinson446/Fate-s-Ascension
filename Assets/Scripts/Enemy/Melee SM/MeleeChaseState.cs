using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeChaseState : MeleeState
{
    public override void Enter()
    {
        meleeEnemy.UpdateGameState("Chase");

        SetMoveSpeed(meleeEnemy.moveSpeed);
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
        Vector3 direction = transform.position - player.transform.position;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 0.1f);
    }

    void ChasePlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
