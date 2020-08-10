using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] int maxNumberOfTowers = 3;
    [SerializeField] Tower towerPrefab = null;
    [SerializeField] GameObject towerParent = null;
    
    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint waypoint) {
        if(towerQueue.Count < maxNumberOfTowers) {
            InstantiateNewTower(waypoint);
        } else {
            MoveExistingTower(waypoint);
        }
    }

    private void InstantiateNewTower(Waypoint waypoint) {
        Tower tower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        
        tower.SetCurrentWaypoint(waypoint);
        tower.GetCurrentWaypoint().isPlaceable = false;
        
        tower.transform.parent = towerParent.transform;
        
        towerQueue.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint newPosition) {
        Tower tower = towerQueue.Dequeue();
        
        tower.GetCurrentWaypoint().isPlaceable = true;
        tower.SetCurrentWaypoint(newPosition);
        tower.transform.position = newPosition.transform.position;
        tower.GetCurrentWaypoint().isPlaceable = false;

        towerQueue.Enqueue(tower);
    }
}
