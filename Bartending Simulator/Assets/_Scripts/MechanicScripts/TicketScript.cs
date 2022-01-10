using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketScript : MonoBehaviour {
    [SerializeField]
    List<GameObject> ticketUI;

    [SerializeField]
    Texture[] textureArray;

    public enum Drinks {
        Daiquiri,
        Margarita,
        Cosmopolitan,
        Long_Island
    }

    private int randomDrink;
    public static Drinks currentDrink;

    private void Awake() {
        // Add objects to List
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("TicketUI")) {
            ticketUI.Add(item);
        }

        // Choose random drink
        randomDrink = Random.Range(0, 3);
        currentDrink = (Drinks)randomDrink;

        // Set Ticket UI
        switch (currentDrink) {
            case Drinks.Daiquiri: {
                    foreach (GameObject item in ticketUI) {
                        if (item.name == "DrinkName") {
                            item.GetComponent<RawImage>().texture = textureArray[2];
                        }
                    }
                    break;
                }
            case Drinks.Margarita: {
                    foreach (GameObject item in ticketUI) {
                        if (item.name == "DrinkName") {
                            item.GetComponent<RawImage>().texture = textureArray[3];
                        }
                    }
                    break;
                }
            case Drinks.Cosmopolitan: {
                    foreach (GameObject item in ticketUI) {
                        if (item.name == "DrinkName") {
                            item.GetComponent<RawImage>().texture = textureArray[4];
                        }
                    }
                    break;
                }
        }
    }
    
}
