using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Softs : MonoBehaviour
{
    private void OnMouseDown() {
        CameraMovement.areSoftBottlesCollected = true;
    }
}
