using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void Attack()
    {
        Collider[] colls = Physics.OverlapSphere(attackPoint.position, attackRange / 2);
        foreach (Collider c in colls)
        {
            if (c.gameObject.tag == "Player")
            {
                Player player = c.GetComponent<Player>();
                player.TakeDamage(attack);
            }
        }
    }
}
