using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour{
   [SerializeField]
   int startingBalance = 150;
   [SerializeField]
   TextMeshProUGUI balancetext;
   public int currentBalance { private set; get; }
   public void deposit(int value) {
        currentBalance += Mathf.Abs(value);
        updateUI();
    }
    public void withdraw(int value) {
        currentBalance -= Mathf.Abs(value);
        if (currentBalance < 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        updateUI();
    }

    private void Awake() {
        currentBalance = startingBalance;
        updateUI();
    }

    void updateUI() {
        balancetext.text = "Gold: " + currentBalance;
    }

}
