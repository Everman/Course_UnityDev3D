using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float maxHitRange = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        RaycastHit rayCastHit;
        if( Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out rayCastHit, maxHitRange)) {
            Debug.Log("Hit: "+rayCastHit.collider.name + " at distance: " + rayCastHit.distance);
        }
    }
}
