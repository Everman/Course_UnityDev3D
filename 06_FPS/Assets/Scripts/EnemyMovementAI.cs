using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    
    [SerializeField] Transform target = null;
    [SerializeField] float chaseRange = 25f;
    [SerializeField] bool debug = false;

    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;

    Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if ( isProvoked ) {
            EngageTarget();
        } else if ( distanceToTarget <= chaseRange ) {
            isProvoked = true;            
        }
    }

    private void EngageTarget() {
        if ( distanceToTarget >= navMeshAgent.stoppingDistance ) {
            ChaseTarget();
        }
        
        if (distanceToTarget < navMeshAgent.stoppingDistance) { 
            AttackTarget();
        } else {
            animator.SetBool("attack", false);
        }
    }

    private void ChaseTarget() {
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() {
        animator.SetBool("attack", true);
    }

    public void provoke() {
        isProvoked = true;
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmos() {
        if (debug) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, chaseRange);

            if (navMeshAgent) {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
            }
        }
    }
}
