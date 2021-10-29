using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour{
    [SerializeField]
    private bool isPlaceable;
    public bool IsPlaceable {
        get { return isPlaceable; }
    }

    [SerializeField]
    private GameObject tower;

    private void OnMouseDown() {       
        if (isPlaceable) {
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
