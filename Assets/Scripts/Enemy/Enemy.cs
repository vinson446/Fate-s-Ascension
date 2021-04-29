using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("State")]
    [SerializeField] string gameState;

    [Header("Movement")]
    public float moveSpeed;

    [Header("Combat Stats")]
    [SerializeField] protected int level;
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected int attack;
    public float attackSpeed;
    [SerializeField] protected int defense;

    [Header("Range Settings")]
    public Transform attackPoint;
    public float aggroRange;
    public float attackRange;

    Player player;
    StateMachine stateMachine;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        stateMachine = GetComponentInChildren<StateMachine>();
    }

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

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        if (GetComponent<MeleeEnemy>() != null)
            stateMachine.ChangeState<MeleeDeathState>();
        else
            stateMachine.ChangeState<RangeDeathState>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, aggroRange);
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
