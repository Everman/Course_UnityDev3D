﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] Text healthText = null;

    [Header("Audio")] [SerializeField] AudioClip damageSFX = null;

    private void Start() {
        healthText.text = playerHealth.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        playerHealth--;

        GetComponent<AudioSource>().PlayOneShot(damageSFX);

        healthText.text = playerHealth.ToString();
        if (playerHealth < 1) {
            Debug.Log("Death");
        }
    }
}
