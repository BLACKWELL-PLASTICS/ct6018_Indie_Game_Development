using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleOrder : MonoBehaviour {
    // This is a array of all of the bottles in the scene
    Bottle[] allBottles;

    // A complete List of the bottles needed for the drink
    List<Bottle> bottlesNeeded = new List<Bottle>();
    // 
    List<Bottle> bottlesCollected = new List<Bottle>(); 
    // Start is called before the first frame update
    void Start() {
        // Fill the array of all the bottles
        allBottles = GameObject.FindObjectsOfType<Bottle>();
        // Get the current drink
        TicketScript ticketScript = GameObject.Find("btn_Ticket").GetComponent<TicketScript>();
        TicketScript.Drinks currentDrink = ticketScript.GetCurrentDrink();

        switch (currentDrink) {
            case TicketScript.Drinks.Daiquiri: {
                    foreach (Bottle item in allBottles) {
                        if (item.gameObject.name == "Rum" || item.gameObject.name == "Lime" ||
                            item.gameObject.name == "Sugar") {
                            bottlesNeeded.Add(item);
                        }
                    }
                    break;
                }
            case TicketScript.Drinks.Margarita: {
                    foreach (Bottle item in allBottles) {
                        if (item.gameObject.name == "Tequila" || item.gameObject.name == "Lime" ||
                            item.gameObject.name == "TripleSec") {
                            bottlesNeeded.Add(item);
                        }
                    }
                    break;
                }
            case TicketScript.Drinks.Cosmopolitan: {
                    foreach (Bottle item in allBottles) {
                        if (item.gameObject.name == "Vodka" || item.gameObject.name == "Lime" ||
                            item.gameObject.name == "Cranberry" || item.gameObject.name == "TripleSec") {
                            bottlesNeeded.Add(item);
                        }
                    }
                    break;
                }
            case TicketScript.Drinks.Long_Island: {
                    foreach (Bottle item in allBottles) {
                        if (item.gameObject.name == "Vodka" || item.gameObject.name == "Rum"
                            || item.gameObject.name == "Tequila" || item.gameObject.name == "Gin"
                            || item.gameObject.name == "TripleSec" || item.gameObject.name == "Lemon"
                            || item.gameObject.name == "Sugar") {
                            bottlesNeeded.Add(item);
                        }
                    }
                    break;
                }
        }
    }

    public void AddBottle(GameObject gameObject) {
        foreach (Bottle item in bottlesNeeded) {
            if (gameObject.name == item.gameObject.name) {
                bottlesCollected.Add(item);
                item.gameObject.SetActive(false);
                int i = Random.Range(1, 3);
                GameObject.Find("as_bottles" + i.ToString()).GetComponent<AudioSource>().Play();
            }
        }
    }

    private void Update() {
        if (bottlesCollected.Count == bottlesNeeded.Count) {
            // All bottles are collected
            CameraMovement.areAlcoholBottlesCollected = true;
        }
    }
}
