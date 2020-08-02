using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan = null;
    [SerializeField] Transform targetEnemy = null;

    private void Start() {
        if (objectToPan == null) { Debug.LogError("objectToPan = null"); }
        if (targetEnemy == null) { Debug.LogError("targetEnemy = null"); }
    }

    private void LookAt() {
        objectToPan.LookAt(targetEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
    }
}
