using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int maxNumberOfTowers = 3;
    [SerializeField] Tower towerPrefab = null;

    public void AddTower(Waypoint waypoint) {
        if(maxNumberOfTowers >= 1) {
            Tower tower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
            waypoint.isPlaceable = false;
            maxNumberOfTowers--;
        } else {
            Debug.LogError("Not allowed to place tower");
        }
    }
}
