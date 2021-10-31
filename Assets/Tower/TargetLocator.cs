using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour{
    [SerializeField]
    GameObject weapon;  
    Transform target;
    [SerializeField]
    float range = 15f;
    [SerializeField]
    ParticleSystem particelSystem;
    void Start(){
      
    }

    // Update is called once per frame
    void Update()
    {
        aimWeapon();
        chooseTarget();
    }

    void aimWeapon() {
        if (target != null) {
            float targetDistance = Vector3.Distance(this.transform.position, target.transform.position);
            attack(targetDistance <= range);
            weapon.transform.LookAt(target);
        }else {
            attack(false);
        }
    }

    void chooseTarget() {
        target = null;
        float minimumDistance = Mathf.Infinity;
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies) {
            if (Vector3.Distance(enemy.transform.position, this.transform.position) < minimumDistance) {
                minimumDistance = Vector3.Distance(enemy.transform.position, this.transform.position);
                target = enemy.gameObject.transform;
            }
        }
    }

    void attack(bool isActive) {
        particelSystem.enableEmission = isActive;
    }
}
