using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour {
    Pouring pouring;
    Rigidbody2D rb;
    float directionY;
    float moveSpeed = 20f;

    float angle;
    float a;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        pouring = GetComponent<Pouring>();
    }

    // Update is called once per frame
    void Update() {
        // direction = the phones acceleration * movement speed
        directionY = -Input.acceleration.x * moveSpeed;
        // Move glass up but clamp the top and bottom position
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 10.40f, 11.40f));

        // As glass moves up, also rotate
        if (angle < 0.95f) {
            if (pouring.isPouring == true) {
                // Play ended pouring sound

            }
            pouring.isPouring = false;
            // rb.rotation
            a = Mathf.Lerp(0.0f, 130.0f, angle * moveSpeed * Time.deltaTime);
            Quaternion target = Quaternion.Euler(0.0f, 0.0f, a);
            transform.rotation = target;
        } else {
            Quaternion target = Quaternion.Euler(0.0f, 0.0f, 130.0f);
            transform.rotation = target;
            // Start pouring
            pouring.isPouring = true;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(0.0f, directionY);
        // angle gets bigger the more the bottle moves up
        angle = transform.position.y - 10.40f;
    }
}
