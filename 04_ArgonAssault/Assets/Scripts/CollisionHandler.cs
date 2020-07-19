using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Duration is seconds before next level is loaded")][SerializeField] float loadLevelDelay = 2f;
    [Tooltip("Prefab used as FX for Death Sequence")][SerializeField] GameObject deathFX = null;

    private void OnTriggerEnter(Collider other) {
        deathSequence();
    }
    private void deathSequence() {
        GetComponent<PlayerController>().SendMessage("PlayDeathSequence");
        deathFX.SetActive(true);
        Invoke("ReloadScene", loadLevelDelay);
    }

    private void ReloadScene() { // String referenced
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
