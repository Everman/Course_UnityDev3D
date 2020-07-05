using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillate : MonoBehaviour
{
    const float tau = Mathf.PI * 2f;

    [SerializeField] Vector3 movementVector;
    [SerializeField] float animationDuration = 2f; //seconds

    //TODO remove from inspector later
    float movementFactor;

    Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        Debug.Log("Transform.position: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / animationDuration; //grows continually from 0
        movementFactor = ( ( Mathf.Sin(cycles * tau ) / 2f ) + 0.5f ); // Sinus goes from -1 to 1, divide it by two and go up a half to go between 0 and 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
