using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    public GameObject[] glass = new GameObject[5]; // 0 - coupe, 1 - martini, 2 - highball, 3 - rock, 4 - spawnpoint
    Rigidbody2D rb;
    float directionY;
    float moveSpeed = 20f;

    // bool for has reached
    // int for amount of times
    bool hasReached = false;
    int count = 0;
    int endCount = 8;
    bool spawned = false;

    TicketScript ticketScript;
    TicketScript.Drinks currentDrink;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        glass[0] = GameObject.Find("Coupe");
        glass[1] = GameObject.Find("Martini");
        glass[2] = GameObject.Find("Highball");
        glass[3] = GameObject.Find("Rock");
        glass[4] = GameObject.Find("GSP");
        ticketScript = GameObject.Find("btn_Ticket").GetComponent<TicketScript>();
        currentDrink = ticketScript.GetCurrentDrink();
    }

    // Update is called once per frame
    void Update()
    {
        if (count != endCount) {
            // direction = the phones acceleration * movement speed
            directionY = -Input.acceleration.x * moveSpeed;
            // Move glass up but clamp the top and bottom position
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 9.68f, 11.68f));

            if (hasReached == false && transform.position.y == 11.68f) {
                hasReached = true;
                count++;
            }
            if (hasReached == true && transform.position.y == 9.68f) {
                hasReached = false;
                count++;
            }
        } else {
            // Spawn Glass
            // End Game Good condition
            int glassNo = 0;
            switch (currentDrink) {
                case TicketScript.Drinks.Daiquiri:
                    glassNo = 0;
                    break;
                case TicketScript.Drinks.Margarita:
                    glassNo = 1;
                    break;
                case TicketScript.Drinks.Cosmopolitan:
                    glassNo = 1;
                    break;
                case TicketScript.Drinks.Long_Island:
                    glassNo = 2;
                    break;
            }
            Debug.LogError(glassNo);
            if (spawned == false) {
                // Spawn Glass
                GameObject newGlass = Instantiate(glass[glassNo], glass[4].transform.position, Quaternion.identity);
                //switch (currentDrink) {
                //    case TicketScript.Drinks.Daiquiri:
                //        newGlass.GetComponent<SpriteRenderer>().color = Color.green;
                //        break;
                //    case TicketScript.Drinks.Margarita:
                //        newGlass.GetComponent<SpriteRenderer>().color = Color.green;
                //        break;
                //    case TicketScript.Drinks.Cosmopolitan:
                //        newGlass.GetComponent<SpriteRenderer>().color = Color.red;
                //        break;
                //    case TicketScript.Drinks.Long_Island:
                //        newGlass.GetComponent<SpriteRenderer>().color = Color.white;
                //        break;
                //}

                Destroy(newGlass.GetComponent<Rigidbody2D>());
                Destroy(newGlass.GetComponent<BoxCollider2D>());
                Destroy(newGlass.GetComponent<Glass>());

                spawned = true;

                // GOOD GAME END

            }
        }
    }

    void FixedUpdate() {
        if (count != endCount) {
            rb.velocity = new Vector2(0.0f, directionY);
        } else {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
