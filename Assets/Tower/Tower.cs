using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{
    [SerializeField]
    int cost=25;
    Bank bank;
    void Awake(){
        bank = FindObjectOfType<Bank>();
    }

    void Update(){
        
    }

    public bool createTower(Tower tower,Vector3 position) {
        bank = FindObjectOfType<Bank>();        
        if (bank != null) {
            if (bank.currentBalance >= cost) {
                Instantiate(tower, position, Quaternion.identity);
                bank.withdraw(cost);
                return true;
            }

        }
        return false;
    }
}
