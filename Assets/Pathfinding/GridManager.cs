using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField]   
    Vector2Int gridSize;
    public Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    [SerializeField]
    [Tooltip("The size of the unity grid snapping")]
    private Vector2Int unityGridSize;
    public Vector2Int UnityGridSize { get { return unityGridSize; } }

    public Dictionary<Vector2Int, Node> Grid { get{ return  grid; } }

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

    public void blockNode(Vector2Int coordinates) {
        if (grid.ContainsKey(coordinates)) {
            grid[coordinates].isWalkable = false;
        }
    }

    public Vector2Int getCoordinatesFromPosition(Vector3 position) {
        return  new Vector2Int(
         Mathf.RoundToInt(position.x / unityGridSize.x),
         Mathf.RoundToInt(position.z / unityGridSize.y));
    }

    public Vector3 getPositionFromCoordinates(Vector2Int coordinates) {
        return new Vector3(unityGridSize.x*coordinates.x,0,unityGridSize.y*coordinates.y);
    }
}
