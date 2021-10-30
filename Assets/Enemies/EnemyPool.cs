using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour{
    [SerializeField]
    private float spawntime = 1f;
    [SerializeField]
    private GameObject enemyPrefab;
    void Start(){
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies() {
        while (true) {
            GameObject.Instantiate(enemyPrefab, this.transform);
            yield return new WaitForSeconds(spawntime);
        }
    }
}
