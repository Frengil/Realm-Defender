using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{
    [SerializeField]
    int cost=25;
    [SerializeField]
    private float buildTime = 1f;
    Bank bank;
    void Awake(){
        bank = FindObjectOfType<Bank>();
    }

    private void Start() {
        StartCoroutine(build());
    }

    IEnumerator build() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child) {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform) {
            yield return new WaitForSeconds(buildTime);
            child.gameObject.SetActive(true);
            foreach (Transform grandchild in child) {
                grandchild.gameObject.SetActive(true);
            }
                
        }
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
