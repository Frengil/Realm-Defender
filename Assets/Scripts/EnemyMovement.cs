using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();

    private void Start() {
        printPath();
    }

    void printPath() {
        foreach(Waypoint wp in path) {
            print(wp.transform.name);
        }
    }
}
