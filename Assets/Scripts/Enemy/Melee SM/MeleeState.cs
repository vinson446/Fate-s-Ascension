using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeState : State
{
    protected StateMachine stateMachine;
    protected MeleeEnemy meleeEnemy;
    protected NavMeshAgent navMeshAgent;

    protected TestPlayerScript player;

    private void Awake()
    {
        stateMachine = GetComponent<MeleeSM>();
        meleeEnemy = GetComponent<MeleeEnemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        player = FindObjectOfType<TestPlayerScript>();
    }

    protected void SetMoveSpeed(float moveSpeed)
    {
        navMeshAgent.speed = moveSpeed;
    }
}
