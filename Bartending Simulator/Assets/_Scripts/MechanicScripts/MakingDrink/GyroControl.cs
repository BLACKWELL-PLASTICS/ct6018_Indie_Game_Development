using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    private GameObject bottleContainer;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        bottleContainer = new GameObject("Bottle Container");
        bottleContainer.transform.position = transform.position;
        transform.SetParent(bottleContainer.transform);

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro() {
        if (SystemInfo.supportsGyroscope) {
            gyro = Input.gyro;
            gyro.enabled = true;

            bottleContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotation = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled) {
            transform.localRotation = gyro.attitude * rotation;
        }
    }
}
