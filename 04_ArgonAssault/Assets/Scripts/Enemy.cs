using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Effects")]
    [Tooltip("Parent where DeathFX should be bound to")][SerializeField] GameObject fxParent = null;
    [Tooltip("Effect to be played on death")] [SerializeField] GameObject deathFX = null;

    [Header("Death")]
    [Tooltip("Time it takes before enemy ship is removed from game")] [SerializeField] float deathDelay = 1f;

    [Header("Score")]
    [Tooltip("Amount of points awarded when calling the ScoreHit function")] [SerializeField] int pointsPerHit = 10;
    [Tooltip("Number of hits required to kill an enemy")] [SerializeField] int maxHits = 10;

    private ScoreBoard scoreBoard;

    private bool alive = true;

    private void Start() {
        AddNonTriggerBoxCollider();
        
        scoreBoard = FindObjectOfType<ScoreBoard>();
        
        NullChecks();
    }

    private void NullChecks() {
        if (deathFX == null) { Debug.LogError("ERROR - Enemy deathFX does not hold a GameObject for: " + this.name); }
        if (fxParent == null) { Debug.LogError("ERROR - Enemy fxParent does not hold a GameObject for: " + this.name); }
        if (scoreBoard == null) { Debug.LogError("Error - Enemy script could not find a scoreboard object!"); }
    }

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        if (alive) {
            scoreBoard.ScoreHit(pointsPerHit);
            if(maxHits < 1) {
                alive = false;
                KillEnemy();
            } else {
                maxHits--;
            }
        }
    }

    private void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = fxParent.transform;
        Invoke("DestroyEnemy", deathDelay);
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }
}
