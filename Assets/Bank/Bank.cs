using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour{
   [SerializeField]
   int startingBalance = 150;
   public int currentBalance { private set; get; }
   public void deposit(int value) {
        currentBalance += Mathf.Abs(value);
    }
    public void withdraw(int value) {
        currentBalance -= Mathf.Abs(value);
        if (currentBalance < 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Awake() {
        currentBalance = startingBalance;
    }

}
