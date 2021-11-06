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
       
    }

    private void Start() {
        startNode = grid[startCoordinate];
        destinationNode = grid[destinationCoordinate];
        breadthFirstSearch();
        List<Node> path=buildPath();
        print(path.Count);

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
                neighbor.connectedTo = currentSearchNode;
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

    List<Node> buildPath() {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath = true;
        while (currentNode.connectedTo != null) {
            currentNode = currentNode.connectedTo;
            currentNode.isPath = true;
            path.Add(currentNode);
        }
        path.Reverse();
        return path;
    }

}
