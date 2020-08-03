using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] bool spawnEnemies = true;
    [SerializeField] Enemy enemyToSpawn = null;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (spawnEnemies) {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
