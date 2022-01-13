using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    BottleOrder order;
    // Start is called before the first frame update
    void Start()
    {
        order = GameObject.Find("Bottles").GetComponent<BottleOrder>();
    }

    private void OnMouseDown() {
        order.AddBottle(this.gameObject);
    }
}
