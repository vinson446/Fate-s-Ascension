using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : State
{
    protected StateMachine stateMachine;
    protected MeleeEnemy meleeEnemy;
    protected TestPlayerScript player;

    private void Awake()
    {
        stateMachine = GetComponent<MeleeSM>();
        meleeEnemy = GetComponent<MeleeEnemy>();
        player = FindObjectOfType<TestPlayerScript>();
    }
}
