using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Waypoints")]
    [Tooltip("List of blocks for enemy path")] [SerializeField] List<Waypoint> path = null;

    [Header("Enemy Properties")]
    [Tooltip("Speef of the enemy in seconds")] [SerializeField] float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start() {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath() {
        print("Starting Patrol!");
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            print("Visiting block: " + waypoint.name);
            yield return new WaitForSeconds(movementSpeed);
        }
        print("Ending Patrol!");
    }
}
