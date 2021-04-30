using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : RangeState
{
    bool isAttacking;

    public override void Enter()
    {
        rangeEnemy.UpdateGameState("Attack");

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
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        transform.parent.LookAt(player.transform);
        animator.CrossFadeInFixedTime("Attack", 0.2f);

        // wait for animation to actually attack
        yield return new WaitForSeconds(1.5f);

        rangeEnemy.Attack();

        yield return new WaitForSeconds(1 / rangeEnemy.attackSpeed);

        isAttacking = false;
    }
}
