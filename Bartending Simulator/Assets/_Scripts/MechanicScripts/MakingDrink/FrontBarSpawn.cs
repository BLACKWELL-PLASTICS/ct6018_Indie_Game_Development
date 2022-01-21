using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBarSpawn : MonoBehaviour {
    public GameObject[] bottles;

    [SerializeField] GameObject[] Shakers = new GameObject[2];

    GameObject bottleSpawnPoint;
    public static int index = 0;
    int i;

    TicketScript ticketScript;
    TicketScript.Drinks currentDrink;

    // Start is called before the first frame update
    void Start() {
        bottleSpawnPoint = GameObject.Find("BSP");
        Shakers[0] = GameObject.Find("Boston_Shaker_Open");
        i = index;
        ticketScript = GameObject.Find("btn_Ticket").GetComponent<TicketScript>();
        currentDrink = ticketScript.GetCurrentDrink();
    }

    bool spawned = false;
    GameObject newBottle;
    // Update is called once per frame
    void Update() {
        if (index != i) {
            spawned = false;
            Destroy(newBottle);
        }

        if (spawned == false) {
            switch (currentDrink) {
                case TicketScript.Drinks.Daiquiri:
                    if (index == 1) {
                        newBottle = Instantiate(bottles[2], bottleSpawnPoint.transform.position, Quaternion.identity); // Rum
                    } else if (index == 2) {
                        newBottle = Instantiate(bottles[9], bottleSpawnPoint.transform.position, Quaternion.identity); // Lime
                    } else if (index == 3) {
                        newBottle = Instantiate(bottles[10], bottleSpawnPoint.transform.position, Quaternion.identity); // Sugar
                    }
                    if (index == 4) {
                        Shakers[0].GetComponent<SpriteRenderer>().sprite = Shakers[1].GetComponent<SpriteRenderer>().sprite;
                        Shakers[0].name = "Boston_Shaker_Closed";
                        Shakers[0].AddComponent<Shaking>();
                        spawned = true;
                    }

                    break;
                case TicketScript.Drinks.Margarita:
                    if (index == 1) {
                        newBottle = Instantiate(bottles[3], bottleSpawnPoint.transform.position, Quaternion.identity); // Tequila
                    } else if (index == 2) {
                        newBottle = Instantiate(bottles[4], bottleSpawnPoint.transform.position, Quaternion.identity); // Triple Sec
                    } else if (index == 3) {
                        newBottle = Instantiate(bottles[9], bottleSpawnPoint.transform.position, Quaternion.identity); // Lime
                    }
                    if (index == 4) {
                        Shakers[0].GetComponent<SpriteRenderer>().sprite = Shakers[1].GetComponent<SpriteRenderer>().sprite;
                        Shakers[0].name = "Boston_Shaker_Closed";
                        Shakers[0].AddComponent<Shaking>();
                        spawned = true;
                    }
                    break;
                case TicketScript.Drinks.Cosmopolitan:
                    if (index == 1) {
                        newBottle = Instantiate(bottles[0], bottleSpawnPoint.transform.position, Quaternion.identity); // Vodka
                    } else if (index == 2) {
                        newBottle = Instantiate(bottles[4], bottleSpawnPoint.transform.position, Quaternion.identity); // Triple Sec
                    } else if (index == 3) {
                        newBottle = Instantiate(bottles[9], bottleSpawnPoint.transform.position, Quaternion.identity); // Lime
                    } else if (index == 4) {
                        newBottle = Instantiate(bottles[5], bottleSpawnPoint.transform.position, Quaternion.identity); // Cranberry
                    }
                    if (index == 5) {
                        Shakers[0].GetComponent<SpriteRenderer>().sprite = Shakers[1].GetComponent<SpriteRenderer>().sprite;
                        Shakers[0].name = "Boston_Shaker_Closed";
                        Shakers[0].AddComponent<Shaking>();
                        spawned = true;
                    }
                    break;
                case TicketScript.Drinks.Long_Island:
                    if (index == 1) {
                        newBottle = Instantiate(bottles[0], bottleSpawnPoint.transform.position, Quaternion.identity); // Vodka
                    } else if (index == 2) {
                        newBottle = Instantiate(bottles[1], bottleSpawnPoint.transform.position, Quaternion.identity); // Gin
                    } else if (index == 3) {
                        newBottle = Instantiate(bottles[2], bottleSpawnPoint.transform.position, Quaternion.identity); // Rum
                    } else if (index == 4) {
                        newBottle = Instantiate(bottles[3], bottleSpawnPoint.transform.position, Quaternion.identity); // Tequila
                    } else if (index == 5) {
                        newBottle = Instantiate(bottles[4], bottleSpawnPoint.transform.position, Quaternion.identity); // Triple Sec
                    } else if (index == 6) {
                        newBottle = Instantiate(bottles[8], bottleSpawnPoint.transform.position, Quaternion.identity); // Lemon
                    } else if (index == 7) {
                        newBottle = Instantiate(bottles[10], bottleSpawnPoint.transform.position, Quaternion.identity); // Sugar
                    }
                    if (index == 8) {
                        Shakers[0].GetComponent<SpriteRenderer>().sprite = Shakers[1].GetComponent<SpriteRenderer>().sprite;
                        Shakers[0].name = "Boston_Shaker_Closed";
                        Shakers[0].AddComponent<Shaking>();
                        spawned = true;
                    }
                    break;
            }
            newBottle.GetComponent<Bottle>().enabled = false;
            newBottle.AddComponent<Accelerometer>();
            newBottle.AddComponent<Pouring>();
            
            spawned = true;
            i = index;
        }
    }
}
