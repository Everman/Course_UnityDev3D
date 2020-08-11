using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;

    private void OnTriggerEnter(Collider other) {
        playerHealth--;
        if(playerHealth < 1) {
            Debug.Log("Death");
        }
    }
}
