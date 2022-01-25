using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pouring : MonoBehaviour {
    // These variables are changed by the accelleromiter script
    public bool isPouring = false;
    public bool StartedPouring = false;
    public bool EndedPouring = false;

    float doubleMeasure = 2.1f; // Double
    float singleMeasure = 1f; // Single
    float tenML = 0.2f; // 10ml

    float timer = 0.0f;

    TicketScript ticketScript;
    TicketScript.Drinks currentDrink;

    // UI and Audio
    Text text;
    AudioSource as_pouringS;
    AudioSource as_pouring;
    AudioSource as_pouringE;

    void Start() {
        // Reference objects
        ticketScript = GameObject.Find("btn_Ticket").GetComponent<TicketScript>();
        currentDrink = ticketScript.GetCurrentDrink();
        text = GameObject.Find("txt_PouringTimer").GetComponent<Text>();

        as_pouringS = GameObject.Find("as_PouringS").GetComponent<AudioSource>();
        as_pouring  = GameObject.Find("as_Pouring").GetComponent<AudioSource>();
        as_pouringE = GameObject.Find("as_PouringE").GetComponent<AudioSource>();

        Timer();
    }

    // Update is called once per frame
    void Update() {
        if (isPouring == true) {
            if (StartedPouring == true) {
                // Play started pouring audio
                as_pouringS.Play();
                // Started Pouring false
                StartedPouring = false;
            }

            if (timer < 0.0f && timer > -1.0f) {
                text.color = Color.green;
            }
            if (timer < -1.0f) {
                text.color = Color.red;
            }
            as_pouring.Play();
            // count down timer
            timer -= Time.deltaTime;
        }

        if (EndedPouring == true) {
            as_pouring.Stop();
            as_pouringE.Play();

            text.color = Color.white;
            if (timer <= 0.0f && timer > -1.0f) {
                // next bottle
                FrontBarSpawn.index++;
                text.text = "";
                Timer();
            } else if (timer <= -1.0f) {
                Crosses.index++;
                FrontBarSpawn.index++;
                text.text = "";
                Timer();
            }
        }

        text.text = timer.ToString();
    }

    void Timer() {
        // Set timer depending on current drink and bottle index
        switch (currentDrink) {
            case TicketScript.Drinks.Daiquiri:
                if (FrontBarSpawn.index == 1) {
                    timer = doubleMeasure;
                } else if (FrontBarSpawn.index == 2) {
                    timer = singleMeasure;
                } else if (FrontBarSpawn.index == 3) {
                    timer = singleMeasure;
                }
                break;
            case TicketScript.Drinks.Margarita:
                if (FrontBarSpawn.index == 1) {
                    timer = doubleMeasure;
                } else if (FrontBarSpawn.index == 2) {
                    timer = singleMeasure;
                } else if (FrontBarSpawn.index == 3) {
                    timer = singleMeasure;
                }
                break;
            case TicketScript.Drinks.Cosmopolitan:
                if (FrontBarSpawn.index == 1) {
                    timer = doubleMeasure;
                } else if (FrontBarSpawn.index == 2) {
                    timer = singleMeasure;
                } else if (FrontBarSpawn.index == 3) {
                    timer = singleMeasure;
                } else if (FrontBarSpawn.index == 4) {
                    timer = doubleMeasure;
                }
                break;
            case TicketScript.Drinks.Long_Island:
                if (FrontBarSpawn.index == 1) {
                    timer = tenML;
                } else if (FrontBarSpawn.index == 2) {
                    timer = tenML;
                } else if (FrontBarSpawn.index == 3) {
                    timer = tenML;
                } else if (FrontBarSpawn.index == 4) {
                    timer = tenML;
                } else if (FrontBarSpawn.index == 5) {
                    timer = tenML;
                } else if (FrontBarSpawn.index == 6) {
                    timer = singleMeasure;
                } else if (FrontBarSpawn.index == 7) {
                    timer = singleMeasure;
                }
                break;
        }

    }

}

