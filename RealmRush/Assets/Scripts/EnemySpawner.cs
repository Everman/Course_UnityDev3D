using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] bool spawnEnemies = true;
    [SerializeField] Enemy enemyToSpawn = null;
    [SerializeField] GameObject enemyParent = null;
    [SerializeField] GameObject particleParent = null;
    [SerializeField] Text numberOfEnemiesTest = null;
    int numberOfEnemies = 0;

    [Header("Audio")] [SerializeField] AudioClip enemySpawnAudio = null;

    private void Start() {
        numberOfEnemiesTest.text = numberOfEnemies.ToString();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (spawnEnemies) {
            Enemy spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            GetComponent<AudioSource>().PlayOneShot(enemySpawnAudio);

            AddScore();

            if (enemyParent != null) {
                spawnedEnemy.transform.parent = enemyParent.transform;
                spawnedEnemy.SetParticleParent(particleParent);
            }

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore() {
        numberOfEnemies++;
        numberOfEnemiesTest.text = numberOfEnemies.ToString();
    }
}
