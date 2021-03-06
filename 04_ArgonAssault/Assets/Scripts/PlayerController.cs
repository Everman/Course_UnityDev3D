﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// todo: Work out why speed starts very fast

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [Tooltip("Speed of the Player Ship")] [SerializeField] float controlSpeed = 40f;

    [Header("Screen-Position Based")]
    [Tooltip("Max offset on the X axis to prevent ship from going off the screen")] [SerializeField] private float maxXOffset = 15f;
    [Tooltip("Max offset on the Y axis to prevent ship from going off the screen")] [SerializeField] private float maxYOffset = 7.5f;
    [Tooltip("Multiplier for the position on the Pitch Axis")] [SerializeField] float positionPitchFactor = -1f;
    [Tooltip("Multiplier for the position on the Yaw Axis")] [SerializeField] float positionYawFactor = 1.25f;

    [Header("Control-Throw Based")]
    [Tooltip("Maximum degree the ship will be tilted in the Pitch axis")] [SerializeField] float controlPitchFactor = -30f;
    [Tooltip("Maximum degree the ship will be tilted in the Roll axis")]  [SerializeField] float controlRollFactor = -30f;

    [Tooltip("Array that should contain all the gun references")] [SerializeField] GameObject[] guns = null;

    float xThrow, yThrow;

    bool controlsEnabled = true;

    private void Start() {
        if (guns.Length == 0) { Debug.LogError("ERROR - No guns assigned to guns array for PlayerController script"); }
    }

    // Update is called once per frame
    void Update() {
        CalculatePosition();
        CalculateRotation();
        ProcessFiring();
    }

    private void ProcessFiring() {
        if (Input.GetButton("Fire1")) {
            SetGunsActive( true );
        } else {
            SetGunsActive( false );
        }
    }

    private void SetGunsActive(bool isActive) {
        foreach (GameObject gun in guns) {
            ParticleSystem.EmissionModule emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    private void CalculateRotation() {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void CalculatePosition() {
        if (controlsEnabled) {
            xThrow = Input.GetAxis("Horizontal");
            yThrow = Input.GetAxis("Vertical");
        }

        float xOffset = Time.deltaTime * controlSpeed * xThrow;
        float yOffset = Time.deltaTime * controlSpeed * yThrow;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -maxXOffset, maxXOffset);
        float clampedYPos = Mathf.Clamp(rawYPos, -maxYOffset, maxYOffset);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void PlayDeathSequence() {
        controlsEnabled = false;
        xThrow = 0;
        yThrow = 0;

    }

}
