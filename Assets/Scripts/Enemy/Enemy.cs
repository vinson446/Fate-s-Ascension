using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("State")]
    [SerializeField] string gameState;

    [Header("Combat Stats")]
    [SerializeField] protected int level;
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attack;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected int defense;

    [Header("Range Settings")]
    public float aggroRange;
    public float attackRange;


    // Start is called before the first frame update
    void Start()
    {
        HPInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HPInit()
    {
        currentHP = maxHP;
    }

    public void UpdateGameState(string state)
    {
        gameState = state;
    }

    public virtual void Attack()
    {

    }

    public void TakeDamage()
    {

    }

    protected void Die()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
        Gizmos.DrawSphere(transform.position, attackRange);
    }
}
