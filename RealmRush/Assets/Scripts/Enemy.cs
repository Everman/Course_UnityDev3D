using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem deathKilledFX = null;
    [SerializeField] ParticleSystem deathEndpointFX = null;
    [SerializeField] ParticleSystem hitFX = null;

    AudioSource audioSource;

    public enum deathType { Killed, EndReached }

    private GameObject particleParent;

    [Tooltip("Amount of hits to take before being destroyed")] [SerializeField] int health = 2;

    [Header("Audio")] 
    [SerializeField] AudioClip damageSFX = null;
    [SerializeField] AudioClip deathSFX = null;
    
    private void Start() {
        if (deathKilledFX == null) { Debug.LogError("Death FX in Enemy script is null"); }
        audioSource = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other) {
        getDamage();
    }

    private void getDamage() {

        audioSource.PlayOneShot(damageSFX);

        if (health <= 1) {
            KillEnemy(deathType.Killed);
        } else {
            playHitEffect();
            health--;
        }
    }

    public void KillEnemy(deathType dt) {
        SpawnEnemyDeathEffect(dt);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(gameObject, 0.2f);
    }

    void SpawnEnemyDeathEffect(deathType dt) {
        ParticleSystem ps = null;

        switch (dt) {
            case deathType.Killed:
                ps = Instantiate(deathKilledFX, transform.position, Quaternion.identity);
                break;
            case deathType.EndReached:
                ps = Instantiate(deathEndpointFX, transform.position, Quaternion.identity);
                break;
            default:
                Debug.LogError("Unkown deathType");
                break;
        }

        ps.transform.parent = particleParent.transform;

        Destroy(ps.gameObject, deathKilledFX.main.duration);
    }

    private void playHitEffect() {
        AudioSource.PlayClipAtPoint(damageSFX, transform.position);

        ParticleSystem ps = Instantiate(hitFX, transform.position, Quaternion.identity);
        ps.transform.parent = particleParent.transform;
        
        Destroy(ps.gameObject, deathKilledFX.main.duration);
    }

    public void SetParticleParent(GameObject newParticleParent) {
        particleParent = newParticleParent;
    }
}
