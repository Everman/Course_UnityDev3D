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

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        navMeshAgent.SetDestination(target.position);
        ChaseCheck();
    }

    private void ChaseCheck() {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange) {
            navMeshAgent.isStopped = false;
        } else {
            navMeshAgent.isStopped = true;
        }
    }

    void OnDrawGizmos() {
        if (debug) {
            Gizmos.color = new Color(1, 1, 0, 0.75F);
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
