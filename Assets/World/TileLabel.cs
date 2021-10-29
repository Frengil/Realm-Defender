using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class TileLabel : MonoBehaviour{
    [SerializeField]
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
  
    void Awake() {        
        
        displayCoordinates();
        updateTileName();
    }
   
    void Update(){
        if (!Application.isPlaying) {
            displayCoordinates();
            updateTileName();
        }
    }

    void displayCoordinates() {        
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);      
        label.text = coordinates.ToString();
    }

    void updateTileName() {
        this.transform.parent.name= coordinates.ToString();
    }
}
