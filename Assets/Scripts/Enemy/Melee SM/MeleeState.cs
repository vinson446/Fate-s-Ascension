using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeState : State
{
    protected StateMachine stateMachine;

    protected MeleeEnemy meleeEnemy;
    protected NavMeshAgent navMeshAgent;
    protected Animator animator;

    protected Player player;

    private void Awake()
    {
        stateMachine = GetComponent<MeleeSM>();

        meleeEnemy = GetComponentInParent<MeleeEnemy>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();

        player = FindObjectOfType<Player>();
    }

    protected void SetMoveSpeed(float moveSpeed)
    {
        navMeshAgent.speed = moveSpeed;
    }
}
