using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();
    [SerializeField]
    float waitTime = 1;

    private void Start() {
        StartCoroutine(printPath());
    }

    IEnumerator printPath() {
        foreach(Waypoint wp in path) {
            this.transform.position = wp.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
