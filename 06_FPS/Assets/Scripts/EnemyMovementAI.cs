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

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        }
    }

    private void ChaseTarget() {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() {
        Debug.Log("Attack my boi");
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
