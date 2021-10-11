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

    public bool isOrderCollected = false;
    public bool areAlcoholBottlesCollected = false;
    public bool areSoftBottlesCollected = false;
    public bool isGlassCollected = false;
    public bool isFridgeRequired = false;

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
                    this.gameObject.transform.position = m_barArray[0].transform.position;
                    if (isOrderCollected == true) {
                        m_cameraPosition = CameraPosition.BackBar;
                    }
                    break;
                }
            case CameraPosition.BackBar: {
                    this.gameObject.transform.position = m_barArray[1].transform.position;
                    if (areAlcoholBottlesCollected == true && isFridgeRequired == false) {
                        m_cameraPosition = CameraPosition.GlassShelves;
                    } 
                    else if (areAlcoholBottlesCollected == true && isFridgeRequired == true) {
                        m_cameraPosition = CameraPosition.Fridge;
                    }
                    break;
                }
            case CameraPosition.Fridge: {
                    this.gameObject.transform.position = m_barArray[2].transform.position;
                    if (areSoftBottlesCollected == true) {
                        m_cameraPosition = CameraPosition.GlassShelves;
                    }
                    break;
                }
            case CameraPosition.GlassShelves: {
                    this.gameObject.transform.position = m_barArray[3].transform.position;
                    if (isGlassCollected == true) {
                        m_cameraPosition = CameraPosition.FrontBar;
                    }
                    break;
                }
        }
    }
}
