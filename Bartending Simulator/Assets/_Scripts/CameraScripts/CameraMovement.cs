using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum CameraPosition {
        FrontBar, // 1st - Should start at the front to get drink request from customer
        BackBar, // 2nd - To collect all alcohol bottles
        Fridge, // Maybe 3rd (Depending on drink order)
        GlassShelves // 3rd/4th - To collect glass type
    };

    [SerializeField] GameObject[] m_barArray = new GameObject[4];

    CameraPosition m_cameraPosition;

    public static bool isOrderCollected = false;
    public static bool isCycleComplete = false;
    public static bool areAlcoholBottlesCollected = false;
    public static bool areSoftBottlesCollected = false;
    public static bool isGlassCollected = false;
    public static bool isFridgeRequired = false;

    // Start is called before the first frame update
    void Start()
    {
        m_cameraPosition = CameraPosition.FrontBar;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_cameraPosition) {
            case CameraPosition.FrontBar: {
                    this.gameObject.transform.position = m_barArray[0].transform.position; // collect order
                    if (isOrderCollected == true && isCycleComplete == false) {
                        m_cameraPosition = CameraPosition.BackBar; // go to collect alcohol bottles
                    }
                    break;
                }
            case CameraPosition.BackBar: {
                    this.gameObject.transform.position = m_barArray[1].transform.position; // collect alcohol
                    if (areAlcoholBottlesCollected == true && isFridgeRequired == false) { // if fridge isnt needed
                        m_cameraPosition = CameraPosition.GlassShelves; // go straight to collecting glass
                    } 
                    else if (areAlcoholBottlesCollected == true && isFridgeRequired == true) { // else if fridge is needed
                        m_cameraPosition = CameraPosition.Fridge; // go to fridge first
                    }
                    break;
                }
            case CameraPosition.Fridge: {
                    this.gameObject.transform.position = m_barArray[2].transform.position; // collect soft bottles for drink
                    if (areSoftBottlesCollected == true) {
                        m_cameraPosition = CameraPosition.GlassShelves; // collect glass
                    }
                    break;
                }
            case CameraPosition.GlassShelves: {
                    this.gameObject.transform.position = m_barArray[3].transform.position; // collect correct glass for drink
                    // then go to make drink
                    if (isGlassCollected == true) {
                        isCycleComplete = true;
                        m_cameraPosition = CameraPosition.FrontBar;
                        // Drink shall now be made
                    }
                    break;
                }
        }
    }
}
