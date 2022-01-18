using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour {
    Rigidbody2D rb;
    float directionY;
    float moveSpeed = 20f;

    float t;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        directionY = -Input.acceleration.x * moveSpeed;
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 10.39f, 11.40f));
        Mathf.Clamp(rb.rotation,0.0f, 145.0f);
        rb.rotation = Mathf.Lerp(0.0f, 150.0f, t * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(0.0f, directionY);
        t = transform.position.y - 10.39f;
    }
}
