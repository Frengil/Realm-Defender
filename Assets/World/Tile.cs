using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    [SerializeField]
    private bool isPlaceable;
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    Pathfinder pathfinder;

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start() {
        if (gridManager != null) {
            coordinates = gridManager.getCoordinatesFromPosition(transform.position);
            if (!isPlaceable) {
                gridManager.blockNode(coordinates);
            }
        }
    }
    public bool IsPlaceable {
        get { return isPlaceable; }
    }

    [SerializeField]
    private Tower tower;

    private void OnMouseDown() {       
        if (gridManager.getNode(coordinates).isWalkable&&
            !pathfinder.willBlockPath(coordinates)) {
            bool placed=tower.createTower(tower,transform.position);
            if (placed) {
                isPlaceable = !placed;
                
                gridManager.blockNode(coordinates);
                pathfinder.notifyReceivers();
            }
        }
    }
}
