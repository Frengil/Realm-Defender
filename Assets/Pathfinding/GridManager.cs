using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField]
    Vector2Int gridSize;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake() {
        initGrid();
    }

    public Node getNode(Vector2Int coordinates) {
        if (grid.ContainsKey(coordinates)) {
            return grid[coordinates];
        }
        return null;
    }

    void initGrid() {
        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {
                grid.Add(new Vector2Int(x, y), new Node(new Vector2Int(x, y), true));
            }
        }
    }
}
