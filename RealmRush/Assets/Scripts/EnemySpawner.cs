using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] bool spawnEnemies = true;
    [SerializeField] Enemy enemyToSpawn = null;
    [SerializeField] GameObject parent = null;
    [SerializeField] GameObject deathFXParent = null;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (spawnEnemies) {
            Enemy enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            enemy.transform.parent = parent.transform;
            enemy.SetDeathFXParent(deathFXParent);
            yield return new WaitForSeconds(2);
        }
    }
}
