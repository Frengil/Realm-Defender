using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Enemy))]
public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    int maxHitPoints = 5;
    [SerializeField]
    [Tooltip("Hitpoint increase after enemy died")]
    int difficultyRamp = 1;
    int currentHitPoints = 0;
    Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable() {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other) {
        processHit();
    }

    void processHit() {
        currentHitPoints--;
        if (currentHitPoints < 1) {
            enemy.rewardGold();
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
