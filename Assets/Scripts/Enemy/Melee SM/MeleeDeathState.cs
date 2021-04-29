using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDeathState : MeleeState
{
    public override void Enter()
    {
        Die();
    }

    void Die()
    {
        animator.CrossFadeInFixedTime("Death", 0.2f);

        navMeshAgent.enabled = false;

        Collider coll = GetComponentInParent<Collider>();
        coll.enabled = false;
    }

    IEnumerator DeathCoroutine()
    {
        float length = 0.1f;

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip c in clips)
        {
            if (c.name == "Death")
            {
                length = c.length;
            }
        }

        yield return new WaitForSeconds(length);

        animator.enabled = false;
        navMeshAgent.enabled = false;

        Collider coll = GetComponentInParent<Collider>();
        coll.enabled = false;
    }
}