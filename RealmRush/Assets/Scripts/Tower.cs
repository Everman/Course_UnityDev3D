using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetEnemy = null;
    [SerializeField] ParticleSystem ps = null;

    [Tooltip("Distance in number of blocks the tower will shoot at the enemy")]
    [SerializeField] int maxShootingDistance = 3;
    
    private void Start() {
        if (objectToPan == null) { Debug.LogError("objectToPan = null"); }
        if (targetEnemy == null) { Debug.LogError("targetEnemy = null"); }
        if (ps == null) { Debug.LogError("ps = null"); }

        maxShootingDistance *= 10; // convert blocks to actual world distance
    }
    void Update() {
        if (targetEnemy) {
            LookAt();
            FireAtEnemy();
        } else {
            EnableTurret(false);
        }
    }
    private void LookAt() {
        objectToPan.LookAt(targetEnemy.transform);
    }

    private void FireAtEnemy() { // todo return bool
        float distance = Vector3.Distance(transform.position, targetEnemy.transform.position);
        if (maxShootingDistance > distance) {
            EnableTurret(true);
        } else {
            EnableTurret(false);
        }
    }

    void EnableTurret(bool enable) {
        ParticleSystem.EmissionModule em = ps.emission;
        em.enabled = enable;
    }
}
