using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeState : State
{
    protected StateMachine stateMachine;

    protected RangeEnemy rangeEnemy;
    protected NavMeshAgent navMeshAgent;
    protected Animator animator;

    protected Player player;

    private void Awake()
    {
        stateMachine = GetComponent<RangeSM>();

        rangeEnemy = GetComponentInParent<RangeEnemy>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();

        player = FindObjectOfType<Player>();
    }

    protected void SetMoveSpeed(float moveSpeed)
    {
        navMeshAgent.speed = moveSpeed;
    }
}
