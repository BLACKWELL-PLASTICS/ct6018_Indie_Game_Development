using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Main Timer
    Text txt_timer;
    public static float timer;

    // Text Timer
    float textTimer;

    // Start is called before the first frame update
    void Start()
    {
        txt_timer = gameObject.GetComponent<Text>();
        // Set length depending on drink type
        timer = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f) {
            // Level Lost
            txt_timer.color = Color.white;
            txt_timer.text = "Timer : 0.0";
            // End Level Condition
            Crosses.index = 3;

        } else {
            // Level still going
            txt_timer.text = "Timer : " + timer.ToString();
            if (timer <= 5.0f) { // Colour Change
                textTimer += Time.deltaTime;

                if (textTimer >= 0.5f && textTimer < 1) {
                    txt_timer.color = Color.red;
                } else if (textTimer >= 1f && textTimer < 1.5f) {
                    txt_timer.color = Color.white;
                } else if (textTimer >= 1.5f && textTimer < 2f) {
                    txt_timer.color = Color.red;
                } else if (textTimer >= 2f && textTimer < 2.5f) {
                    txt_timer.color = Color.white;
                } else if (textTimer >= 2.5f && textTimer < 3f) {
                    txt_timer.color = Color.red;
                } else if (textTimer >= 3f && textTimer < 3.5f) {
                    txt_timer.color = Color.white;
                } else if (textTimer >= 3.5f && textTimer < 4f) {
                    txt_timer.color = Color.red;
                } else if (textTimer >= 4f && textTimer < 4.5f) {
                    txt_timer.color = Color.white;
                } else if (textTimer >= 4.5f && textTimer < 5f) {
                    txt_timer.color = Color.red;
                }
            }
        }
    }
}
