using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();
    [SerializeField]
    [Range(0,5)]
    float speed = 1;
    Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable() {
        findPath();
        beamToFirstWaypoint();
        StartCoroutine(moveOnPath());
    }

    IEnumerator moveOnPath() {
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
        finishPath();
    }

    void findPath() {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform) {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null) {
                path.Add(waypoint);
            }
        }
    }

    void finishPath() {
        enemy.stealGold();
        gameObject.SetActive(false);
    }

    void beamToFirstWaypoint() {
        transform.position = path[0].transform.position;
    }
}
