using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    TestPlayerScript player;

    private void Start()
    {
        player = FindObjectOfType<TestPlayerScript>();
    }

    public override void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1 / attackSpeed;

            player.TakeDamage(attack);
        }
    }
}
