using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera mainCamera = null;
    [SerializeField] float maxHitRange = 100f;
    [SerializeField] float amountOfDamage = 50f;
    [SerializeField] ParticleSystem muzzleFlash = null;
    [SerializeField] GameObject hitEffect = null;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            muzzleFlash.Play();
        }
    }

    private void Shoot() {
        ProcessRaycast();
    }

    private void ProcessRaycast() {
        RaycastHit rayCastHit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out rayCastHit, maxHitRange)) {
            DamageEnemy(rayCastHit);
            playHitEffect(rayCastHit);
        }
    }

    private void playHitEffect(RaycastHit rayCastHit) {
        GameObject test = Instantiate(hitEffect, rayCastHit.point, Quaternion.LookRotation(rayCastHit.normal));
        Destroy(test, 1f);
    }

    private void DamageEnemy(RaycastHit rayCastHit) {
        EnemyHealth target = rayCastHit.transform.GetComponent<EnemyHealth>();
        if (target) {
            target.TakeDamage(amountOfDamage);
        }
    }
}
