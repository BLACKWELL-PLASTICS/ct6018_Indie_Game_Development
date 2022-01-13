using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassNeeded : MonoBehaviour
{
    Glass[] allGlasses;

    Glass glassNeeded;
    // Start is called before the first frame update
    void Start()
    {
        // Fill the array of all the bottles
        allGlasses = GameObject.FindObjectsOfType<Glass>();

        // Get the current drink
        TicketScript ticketScript = GameObject.Find("btn_Ticket").GetComponent<TicketScript>();
        TicketScript.Drinks currentDrink = ticketScript.GetCurrentDrink();

        switch (currentDrink) {
            case TicketScript.Drinks.Daiquiri: {
                    foreach (Glass item in allGlasses) {
                        if (item.gameObject.name == "Coupe") {
                            glassNeeded = item;
                        }
                    }
                    break;
                }
            case TicketScript.Drinks.Margarita: {
                    foreach (Glass item in allGlasses) {
                        if (item.gameObject.name == "Martini") {
                            glassNeeded = item;
                        }
                    }
                    break;
                }
            case TicketScript.Drinks.Cosmopolitan: {
                    foreach (Glass item in allGlasses) {
                        if (item.gameObject.name == "Martini") {
                            glassNeeded = item;
                        }
                    }
                    break;
                }
            case TicketScript.Drinks.Long_Island: {
                    foreach (Glass item in allGlasses) {
                        if (item.gameObject.name == "Highball") {
                            glassNeeded = item;
                        }
                    }
                    break;
                }
        }
    }

    public void AddGlass(GameObject gameObject) {
        if (gameObject.name == glassNeeded.name) {
            // Correct Choice
            CameraMovement.isGlassCollected = true;
            GameObject.Find("as_glass").GetComponent<AudioSource>().Play();

        }
    }

}
