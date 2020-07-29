using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorGridSnap : MonoBehaviour
{

    //todo fix that gridsize is no longer + 1 
    [Tooltip("Gridsize + 1")] [SerializeField] [Range(1, 20)] int gridSize = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * transform.localScale.x;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * transform.localScale.z;

        if (snapPos.x > (gridSize * transform.localScale.x)) { snapPos.x = gridSize * transform.localScale.x; }
        if (snapPos.x < 0) { snapPos.x = 0f; }
        if (snapPos.z > (gridSize * transform.localScale.z)) { snapPos.z = gridSize * transform.localScale.z; }
        if (snapPos.z < 0) { snapPos.z = 0f; }

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
    }
}
