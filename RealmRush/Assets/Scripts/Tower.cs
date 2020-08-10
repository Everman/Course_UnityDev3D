using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField] ParticleSystem ps = null;
    Enemy targetEnemy = null;

    [Tooltip("Distance in number of blocks the tower will shoot at the enemy")]
    [SerializeField] int maxShootingDistance = 3;

    Waypoint currentWaypoint;

    private void Start() {
        if (objectToPan == null) { Debug.LogError("objectToPan = null"); }
        if (ps == null) { Debug.LogError("ps = null"); }

        maxShootingDistance *= 10; // convert blocks to actual world distance
    }
    void Update() {
        SetTargetEnemy();
        if (targetEnemy) {
            LookAt();
            FireAtEnemy();
        } else {
            targetEnemy = FindObjectOfType<Enemy>();
            if (targetEnemy == null) {
                EnableTurret(false);
            }
        }
    }

    private void SetTargetEnemy() {
        Enemy[] enemiesInScene = FindObjectsOfType<Enemy>();
        if (enemiesInScene.Length == 0) { return; }
        
        Enemy closestEnemy = enemiesInScene[0];
        foreach(Enemy testEnemy in enemiesInScene) {
            closestEnemy = GetClosest(closestEnemy, testEnemy);
        }

        targetEnemy = closestEnemy;
    }

    private Enemy GetClosest(Enemy enemyA, Enemy enemyB) {
        float distanceA = Vector3.Distance(transform.position, enemyA.transform.position);
        float distanceB = Vector3.Distance(transform.position, enemyB.transform.position);
        if (distanceA < distanceB) {
            return enemyA;
        } else {
            return enemyB;
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

    public Waypoint GetCurrentWaypoint() {
        return currentWaypoint;
    }

    public void SetCurrentWaypoint(Waypoint waypoint) {
        currentWaypoint = waypoint;
    }
}
