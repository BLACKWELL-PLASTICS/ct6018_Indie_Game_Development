using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketScript : MonoBehaviour {
    [SerializeField]
    List<GameObject> ticketUI;

    [SerializeField]
    Texture[] textureArray;

    public AudioSource notificationBell;

    public enum Drinks {
        Daiquiri,
        Margarita,
        Cosmopolitan,
        Long_Island
    }

    private int randomDrink;
    public Drinks currentDrink;
    
    int index = 0;

    private void Awake() {
        // Add objects to List
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("TicketUI")) {
            ticketUI.Add(item);
            if (item.name == "TicketExpanded" || item.name == "RecipieBook") {
                item.gameObject.SetActive(false);
            }
        }
        ResetDrink();
    }

    private void Update() {
        if (index == 2) {
            CameraMovement.isOrderCollected = true;
            index++;
        }
    }

    public void OpenTicket() {
        foreach (GameObject item in ticketUI) {
            if (item.name == "img_notification") {
                item.SetActive(false);
                index++;
            }
            else if (item.name == "RecipieBook") {
                item.SetActive(false);
            }
        }
    }

    public void CloseTicket() {
        foreach (GameObject item in ticketUI) {
            if (item.name == "TicketExpanded" && item.activeInHierarchy == true) {
                item.SetActive(false);
                index++;
            }
        }
    }

    private void ResetDrink() {
        index = 0;
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
        // Play Audio and Notification
        foreach (GameObject item in ticketUI) {
            if (item.name == "img_notification") {
                item.gameObject.SetActive(true);
                notificationBell.Play();
            }
        }
    }
}
