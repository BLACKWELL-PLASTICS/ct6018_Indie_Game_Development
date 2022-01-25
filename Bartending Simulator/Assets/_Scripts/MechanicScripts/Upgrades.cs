using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text text;
    int money;
    // Update is called once per frame
    void Update()
    {
        money = SavingSystem.LoadInt("PlayerMoney");
        if (money >= 10000 && SavingSystem.LoadInt("BarUpgrade") == 0) {
            gameObject.GetComponent<Button>().interactable = true;
        } else {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void UpgradeBar() {
        SavingSystem.SaveInt("BarUpgrade", 1);
        text.gameObject.SetActive(true);
    }
}
