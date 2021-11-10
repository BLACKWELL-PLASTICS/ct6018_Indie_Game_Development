using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public List<GameObject> m_gameObjects;

    public void DeactivateObjects() {
        foreach (GameObject item in m_gameObjects) {
            item.SetActive(false);
        }
    }

    public void ActivateObjects() {
        foreach (GameObject item in m_gameObjects) {
            item.SetActive(true);
        }
    }
}