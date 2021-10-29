using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class TileLabel : MonoBehaviour{
    [SerializeField]
    Color defaultColor = Color.white;
    [SerializeField]
    Color blockedColor = Color.gray;
    [SerializeField]
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    [SerializeField]
    Waypoint waypoint;
  
    void Awake() {
        waypoint = GetComponentInParent<Waypoint>();
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
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);      
        label.text = coordinates.ToString();
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    void updateTileName() {
        this.transform.parent.name= coordinates.ToString();
    }

    void toogleCoordinates() {
        if (Input.GetKeyUp(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }
}
