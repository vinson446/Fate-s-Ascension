using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeState : State
{
    protected StateMachine stateMachine;
    protected RangeEnemy rangeEnemy;
    protected TestPlayerScript player;

    private void Awake()
    {
        stateMachine = GetComponent<RangeSM>();
        rangeEnemy = GetComponent<RangeEnemy>();
        player = FindObjectOfType<TestPlayerScript>();
    }
}
