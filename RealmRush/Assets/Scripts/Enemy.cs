using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject deathFXParent = null;
    [SerializeField] GameObject deathFX = null;

    [Tooltip("Amount of hits to take before being destroyed")] [SerializeField] int health = 2;

    private void Start() {
        if (deathFX == null) { Debug.LogError("Death FX in Enemy script is null"); }
    }

    void OnParticleCollision(GameObject other) {
        getDamage();
    }

    private void getDamage() {
        if(health <= 1) {
            playHitEffect();
            Destroy(gameObject, 0.3f);
        } else {
            health--;
        }
    }
    private void playHitEffect() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = deathFXParent.transform;
    }

    public void SetDeathFXParent(GameObject parent) {
        deathFXParent = parent;
    }
}
