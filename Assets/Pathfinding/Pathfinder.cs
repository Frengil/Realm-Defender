using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour{
    [SerializeField]
    Node currentSearchNode;

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    Dictionary<Vector2Int, Node> grid;

    GridManager gridManager;
    void Awake(){
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null) {
            grid = gridManager.Grid;
        }
    }

    private void Start() {
        exploreNeighbors();
    }

    List<Node> exploreNeighbors() {
        List<Node> neighbors = new List<Node>();
        foreach(Vector2Int dir in directions) {
            Vector2Int newCoordinate = currentSearchNode.coordinates + dir;
            if (grid.ContainsKey(newCoordinate)) {
                neighbors.Add(grid[newCoordinate]);
                print("Hallo");
                //TODO : remove afterwards
                grid[newCoordinate].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
        return neighbors;
    }

}
