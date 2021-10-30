using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour{
    [SerializeField]
    private float spawntime = 1f;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    int poolSize = 5;
    private GameObject[] pool;

    void Awake() {
        populatePool();
    }
    void Start(){
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies() {
        while (true) {
            enableEnemy();
            yield return new WaitForSeconds(spawntime);
        }
    }

    void populatePool() {
        pool = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++) {
            pool[i]= Instantiate(enemyPrefab, this.transform); ;
            pool[i].SetActive(false);
        }
    }

    void enableEnemy() {
        for(int i = 0; i < poolSize; i++) {
            if (!pool[i].activeInHierarchy) {
                pool[i].SetActive(true);
                break;
            }
        }
    }
}
