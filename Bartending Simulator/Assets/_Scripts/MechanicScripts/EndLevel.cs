﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public static bool GameEndedGood = false;
    // UI
    [SerializeField] Text   txt_MoneyMade;
    [SerializeField] Button btn_Menu;
    [SerializeField] Button btn_Restart;

    private void Start() {
        txt_MoneyMade.gameObject.SetActive(false);
        btn_Menu.gameObject.SetActive(false);
        btn_Restart.gameObject.SetActive(false);
    }

    public void GoodEnding() {
        GameEndedGood = true;
        Timer.timer = 0.0f;
        int money = SavingSystem.LoadInt("PlayerMoney");
        // GOOD GAME END
        if (Crosses.index == 0) { // NO Cross
            // Most Money
            SavingSystem.SaveInt("PlayerMoney", money + 100);
            txt_MoneyMade.text = "+100 !";
        } else if (Crosses.index == 1) { // 1 Cross
            // Middle Money
            SavingSystem.SaveInt("PlayerMoney", money + 50);
            txt_MoneyMade.text = "+50 !";
        } else if (Crosses.index == 2) { // 2 Cross
            // Least Money
            SavingSystem.SaveInt("PlayerMoney", money + 20);
            txt_MoneyMade.text = "+20 !";
        }
        btn_Menu.gameObject.SetActive(true);
    }

    public void BadEnding() {
        // Ask to restart Level or Menu
        btn_Menu.gameObject.SetActive(true);
        btn_Restart.gameObject.SetActive(true);

    }

    public void Menu() {
        // Load Menu Scene
        SceneManager.LoadScene(0);
    }
    public void RestartLevel() {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
