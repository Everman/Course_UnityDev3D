using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [Tooltip("Waypoint used as start")] [SerializeField] Waypoint startWaypoint = null;
    [Tooltip("Waypoint used as end")] [SerializeField] Waypoint endWaypoint = null;

    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Waypoint searchCenter;

    private Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        FindPath();
    }

    private void FindPath() {
        queue.Enqueue(startWaypoint);
        startWaypoint.isExplored = true;
        
        while(queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }

        print("Done pathfinding?"); // todo remove log
    }

    private void HaltIfEndFound() {
        if (searchCenter == endWaypoint) {
            isRunning = false;
        }
    }

    private void ExploreNeighbors() {
        if (!isRunning) { return; }
        
        foreach(Vector2Int direction in directions) {
            Waypoint neighborWaypoint;
            if (grid.TryGetValue(searchCenter.GetGridPos() + direction, out neighborWaypoint)) {
                QueueNeighbour(neighborWaypoint);
            }
        }
    }

    private void QueueNeighbour(Waypoint neighbour) {
        if (!neighbour.isExplored && !queue.Contains(neighbour)) {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd() {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            if (!grid.ContainsKey(waypoint.GetGridPos())) {
                grid.Add(waypoint.GetGridPos(), waypoint);
            } else {
                Debug.LogWarning("Skipping overlapping block: " + waypoint.name);
            }
        }
    }

    public Waypoint getStartPoint() {
        return startWaypoint;
    }

    public Waypoint getEndPoint() {
        return endWaypoint;
    }
}
