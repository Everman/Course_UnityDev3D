using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float amount) {
        GetComponent<EnemyMovementAI>().provoke();
        health -= amount;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
