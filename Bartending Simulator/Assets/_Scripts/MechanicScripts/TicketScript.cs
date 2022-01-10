using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketScript : MonoBehaviour {
    [SerializeField]
    List<GameObject> ticketUI;

    //UserInterface ticketUI;

    enum Drinks {
        Daiquiri,
        Margarita,
        Cosmopolitan,
        Long_Island
    };

    private int randomDrink;
    private Drinks currentDrink;

    private void Start() {
        //ticketUI = new UserInterface();

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("TicketUI")) {
            ticketUI.Add(item);
            item.SetActive(false);
        }

        randomDrink = Random.Range(0, 3);
        currentDrink = (Drinks)randomDrink;
    }

    private void OnMouseDown() {
        foreach (GameObject item in ticketUI) {
            item.SetActive(true);
        }

        switch (currentDrink) {
            case Drinks.Daiquiri: {

                    break;
                }
            case Drinks.Margarita: {

                    break;
                }
            case Drinks.Cosmopolitan: {

                    break;
                }
        }
    }
}
