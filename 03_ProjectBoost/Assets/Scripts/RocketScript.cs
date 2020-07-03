using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    // Component references
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    // Modifiable variables
    [SerializeField] private float rotationSpeed = 0;
    [SerializeField] private float thrustPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotation();
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * thrustPower);
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
        } else {
            audioSource.Pause();
        }
    }

    private void Rotation() {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
            Debug.Log("Left and/or Right pressed");
        } else if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        } else if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision collision) {

        switch (collision.transform.tag) {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Fuel":
                Debug.Log("Power Up");
                break;
            default:
                Debug.Log("Died!");
                break;
                

        }
    }
}
