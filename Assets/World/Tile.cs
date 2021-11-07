using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{
    [SerializeField]
    private bool isPlaceable;
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
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
        if (isPlaceable) {
            bool placed=tower.createTower(tower,transform.position);            
            isPlaceable = !placed;
        }
    }
}
