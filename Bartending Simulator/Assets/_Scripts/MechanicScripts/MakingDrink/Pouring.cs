using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    public bool isPouring = false;
    public bool StartedPouring = false;
    public bool EndedPouring = false;

    float timer = 2.3f; // 2

    // Update is called once per frame
    void Update()
    {
        if (isPouring == true) {
            timer -= Time.deltaTime;
            if (StartedPouring == true) {
                // Play started pouring audio

                StartedPouring = false;
            }


        }
    }
}
