using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour{
    [SerializeField]
    GameObject weapon;  
    Transform target;
    void Start(){
        target= FindObjectOfType<EnemyMovement>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        aimWeapon();   
    }

    void aimWeapon() {
        weapon.transform.LookAt(target);
    }
}
