using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();
    [SerializeField]
    [Range(0,5)]
    float speed = 1;

    private void Start() {
        StartCoroutine(printPath());
    }

    IEnumerator printPath() {
        foreach(Waypoint wp in path) {
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = wp.transform.position;
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1) {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
           

        }
    }
}
