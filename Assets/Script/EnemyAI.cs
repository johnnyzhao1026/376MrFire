using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    NavMeshAgent navMeshAgent;
    public float chaseRange = 5f;

    float distanceToTarget = Mathf.Infinity;
    Animator anim;

    float turnSpeed;
    bool isProvoked;
    EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        isProvoked = false;
        anim = gameObject.GetComponent<Animator>();
        turnSpeed = 5f;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.IsDead()) // no need to chase player after die
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(transform.position, player.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRange) 
        {
            isProvoked = true;
        }
    }


    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        anim.SetBool("Attack",false);
        anim.SetTrigger("Move");
        navMeshAgent.SetDestination(player.position);
    }

    private void AttackTarget()
    {
        anim.SetBool("Attack", true);
        //Debug.Log("attack player");
    }

    private void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    // if enemy got shot from far away
    public void OnTakenDamage()
    {
        isProvoked = true;
    }

    // draw enemy view range
    private void OnDrawGizmosSelected()  
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
