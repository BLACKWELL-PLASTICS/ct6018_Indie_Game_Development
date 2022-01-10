using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
    public void OnOff(GameObject obj) {
        bool ison = obj.activeInHierarchy;
        obj.gameObject.SetActive(!ison);
    }
}
