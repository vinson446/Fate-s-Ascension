using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    [Header("Range Enemy Settings")]
    [SerializeField] GameObject projectile;
    [SerializeField] float throwForce;

    public override void Attack()
    {
        GameObject proj = Instantiate(projectile, attackPoint.position, Quaternion.identity);

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);

        Projectile p = proj.GetComponent<Projectile>();
        p.damage = attack;
    }
}
