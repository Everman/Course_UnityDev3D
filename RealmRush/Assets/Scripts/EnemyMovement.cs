using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Properties")]
    [Tooltip("Speed of the enemy in seconds")] [SerializeField] float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start() {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));

    }

    IEnumerator FollowPath(List<Waypoint> path) {
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementSpeed);
        }

        EndAction();
    }

    private void EndAction() {
        Enemy enemy = GetComponent<Enemy>();
        enemy.KillEnemy(Enemy.deathType.EndReached);
    }
}
