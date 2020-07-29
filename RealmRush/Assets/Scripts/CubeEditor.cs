using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Waypoint))]
[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    private Waypoint waypoint;

    private void Awake() {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update() {
        SnapToPosition();
        UpdateLabel();
    }

    private void SnapToPosition() {
        int gridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3(
            waypoint.GetGridPos().x, 
            0f,
            waypoint.GetGridPos().y
        );
    }

    private void UpdateLabel() {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
