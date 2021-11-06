using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour{
    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    [SerializeField]
    Vector2Int startCoordinate;
    [SerializeField]
    Vector2Int destinationCoordinate;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    GridManager gridManager;
    void Awake(){
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null) {
            grid = gridManager.Grid;
        }
        startNode = new Node(startCoordinate, true);
        destinationNode = new Node(destinationCoordinate, true);
    }

    private void Start() {
        breadthFirstSearch();
    }

    void exploreNeighbors() {
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int dir in directions) {
            Vector2Int newCoordinate = currentSearchNode.coordinates + dir;
            if (grid.ContainsKey(newCoordinate)) {
                neighbors.Add(grid[newCoordinate]);             
            }
        }
        foreach(Node neighbor in neighbors) {
            if (neighbor.isWalkable && !reached.ContainsKey(neighbor.coordinates)) {
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void breadthFirstSearch() {
        bool isRunning = true;
        frontier.Enqueue(startNode);
        reached.Add(startCoordinate, startNode);
        while (frontier.Count > 0 && isRunning) {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            exploreNeighbors();
            if (currentSearchNode.coordinates == destinationCoordinate) {
                isRunning = false;
            }

        }
    }

}
