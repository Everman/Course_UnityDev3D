using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] bool spawnEnemies = true;
    [SerializeField] Enemy enemyToSpawn = null;
    [SerializeField] GameObject enemyParent = null;
    [SerializeField] GameObject particleParent = null;

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (spawnEnemies) {
            Enemy spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            if(enemyParent != null) {
                spawnedEnemy.transform.parent = enemyParent.transform;
                spawnedEnemy.SetParticleParent(particleParent);
            }
            
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
