using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MeleeState
{
    bool isAttacking;

    public override void Enter()
    {
        meleeEnemy.UpdateGameState("Attack");

        SetMoveSpeed(0);
    }

    public override void Tick()
    {
        if (!isAttacking)
        {
            CheckRanges();

            Attack();
        }
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
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        animator.CrossFadeInFixedTime("Attack", 0.2f);

        // wait for animation to actually attack
        yield return new WaitForSeconds(1.5f);

        meleeEnemy.Attack();

        yield return new WaitForSeconds(1 / meleeEnemy.attackSpeed);

        isAttacking = false;
    }
}
