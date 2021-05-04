using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] int hp;
    public int HP { get => hp; set => hp = value; }
    public int attack;
    public float attackRange;

    public Transform attackPoint;
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;

    private AudioSource audioSrc;
    public AudioClip swordSwing;

    [SerializeField] Animator animator;
    private double waitTimerToMove = 0;
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        uiManager = FindObjectOfType<UIManager>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         handleMovement();
         handleSkills();

    }

    //Timer to make the character idle if casting an effect
    void handleMovement()
    {
        if (myAgent == null)
            return;

        if (animator != null)
        {
            if (myAgent.velocity.magnitude > 0.1f)
                animator.SetFloat("Move", myAgent.velocity.magnitude);
            else
                animator.SetFloat("Move", 0);
        }

        if (waitTimerToMove > 0)
        {
            waitTimerToMove -= Time.deltaTime;
            if (waitTimerToMove <= 0)
                myAgent.isStopped = false;
            return;
        }


        //move to clicked position
        if (Input.GetMouseButtonDown(1))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        uiManager.UpdatePlayerHealth();
    }

    void handleSkills()
     {
         if (waitTimerToMove > 0)
             return;

         //button press = skill
         if (Input.GetButtonDown("Fire1"))
            castSkillEffect();
     }

     void castSkillEffect()
     {
        myAgent.isStopped = true; //Force agent to stop, we want the effects to be played in the same place
        myAgent.velocity = Vector3.zero;
        waitTimerToMove = .5;

        if (animator != null)
        {
            animator.SetTrigger("BasicSlash"); //Play our shout animation from Animator
        }

        audioSrc.clip = swordSwing;
        audioSrc.Play();
        Attack();
    }

    void Attack()
    {
        Collider[] colls = Physics.OverlapSphere(attackPoint.position, attackRange);
        foreach (Collider c in colls)
        {
            if (c.gameObject.tag == "Enemy")
            {
                Enemy enemy = c.GetComponent<Enemy>();
                enemy.TakeDamage(attack);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
