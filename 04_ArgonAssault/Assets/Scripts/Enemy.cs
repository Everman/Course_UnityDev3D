using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Effect to be played on death")] [SerializeField] GameObject deathFX = null;
    [Tooltip("Time it takes before enemy ship is removed from game")] [SerializeField] float deathDelay = 1f;

    private void Start() {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        deathFX.SetActive(true);
        Invoke("DestroyEnemy", deathDelay);
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }
}
