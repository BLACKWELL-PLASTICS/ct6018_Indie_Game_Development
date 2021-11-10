using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gameObjects;

    UserInterface ticketUI;

    private void Start() {
        ticketUI = new UserInterface();

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("TicketUI")) {
            gameObjects.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            RaycastHit2D hit;
            Ray2D ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Casts the ray and get the first game object hit
            if (Physics2D.Raycast(ray, out hit)
               {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == this.gameObject.name) {
                    ticketUI.m_gameObjects = gameObjects;
                    ticketUI.ActivateObjects();
                }
            }
        }
    }
}
