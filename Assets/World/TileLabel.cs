using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]

[RequireComponent(typeof(TextMeshPro))]
public class TileLabel : MonoBehaviour{
    [SerializeField]
    Color defaultColor = Color.white;
    [SerializeField]
    Color blockedColor = Color.gray;
    [SerializeField]
    Color exploredColor = Color.blue;
    [SerializeField]
    Color pathColor = Color.red;
    [SerializeField]
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;
  
    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        displayCoordinates();
        updateTileName();
       
    }
   
    void Update(){
        if (!Application.isPlaying) {
            displayCoordinates();
            updateTileName();
        }
        toogleCoordinates();
        displayCoordinates();
    }

    void displayCoordinates() {
        if (gridManager == null) {
            return;
        }
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x /gridManager.UnityGridSize.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize.y);      
        label.text = coordinates.ToString();
        if (gridManager == null) {
            return;
        }
        setLabelColor();
    }

    void updateTileName() {
        this.transform.parent.name= coordinates.ToString();
    }

    void setLabelColor() {
        Node node = gridManager.getNode(coordinates);
        if (node == null) {
            return;
        }
        if (!node.isWalkable) {
            label.color = blockedColor;
        } else if (node.isPath) {
            label.color = pathColor;
        } else if (node.isExplored) {
            label.color = exploredColor;
        }
       else {
            label.color = defaultColor;
        }
    }

    void toogleCoordinates() {
        if (Input.GetKeyUp(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }
}
