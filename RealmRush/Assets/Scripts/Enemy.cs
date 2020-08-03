using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = null;
    [SerializeField] GameObject hitFX = null;

    [Tooltip("Amount of hits to take before being destroyed")] [SerializeField] int health = 2;

    private void Start() {
        if (deathFX == null) { Debug.LogError("Death FX in Enemy script is null"); }
    }

    void OnParticleCollision(GameObject other) {
        getDamage();
    }

    private void getDamage() {
        if(health <= 1) {
            PlayDeathFX();
            Destroy(gameObject, 0.3f);
        } else {
            playHitEffect();
            health--;
        }
    }

    private void PlayDeathFX() {
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }

    private void playHitEffect() {
        Instantiate(hitFX, transform.position, Quaternion.identity);
    }
}
