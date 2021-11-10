using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour{
    List<Node> path = new List<Node>();
    [SerializeField]
    [Range(0,5)]
    float speed = 1;
    Enemy enemy;

    Pathfinder pathfinder;
    GridManager gridManager;



    private void Awake() {
        enemy = GetComponent<Enemy>();
        pathfinder = FindObjectOfType<Pathfinder>();
        gridManager = FindObjectOfType<GridManager>();
    }

    private void OnEnable() {
        beamToFirstWaypoint();
        recalculatePath(true);     
      
    }

    IEnumerator moveOnPath() {

        for (int i=1;i< path.Count; i++){ 
        
            Vector3 startPosition = this.transform.position;
            Vector3 endPosition = gridManager.getPositionFromCoordinates(path[i].coordinates);
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

    public void recalculatePath(bool resetPath) {       
        Vector2Int coordinates = new Vector2Int();
        if (resetPath) {
            coordinates = pathfinder.StartCoordinate;
        }else {
            coordinates = gridManager.getCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathfinder.getNewPath(coordinates);
        StartCoroutine(moveOnPath());
    }

    void finishPath() {
        enemy.stealGold();
        gameObject.SetActive(false);
    }

    void beamToFirstWaypoint() {
        transform.position = gridManager.getPositionFromCoordinates(pathfinder.StartCoordinate);
    }
}
