using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("Max offset to prevent ship from going off the screen")]
    [SerializeField] private float maxXOffset = 15f;
    [Tooltip("Max offset to prevent ship from going off the screen")]
    [SerializeField] private float maxYOffset = 7.5f;

    [Tooltip("Speed in m/s ^ -1")] 
    [SerializeField] float speed = 40f;

    float xThrow, yThrow;
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 1.25f;
    [SerializeField] float controlRollFactor = -30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        CalculatePosition();
        CalculateRotation();
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
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        float xOffset = Time.deltaTime * speed * xThrow;
        float yOffset = Time.deltaTime * speed * yThrow;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -maxXOffset, maxXOffset);
        float clampedYPos = Mathf.Clamp(rawYPos, -maxYOffset, maxYOffset);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
