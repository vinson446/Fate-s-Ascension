using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeState : State
{
    protected StateMachine stateMachine;
    protected RangeEnemy rangeEnemy;
    protected NavMeshAgent navMeshAgent;

    protected TestPlayerScript player;

    private void Awake()
    {
        stateMachine = GetComponent<RangeSM>();
        rangeEnemy = GetComponent<RangeEnemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        player = FindObjectOfType<TestPlayerScript>();
    }

    protected void SetMoveSpeed(float moveSpeed)
    {
        navMeshAgent.speed = moveSpeed;
    }
}
