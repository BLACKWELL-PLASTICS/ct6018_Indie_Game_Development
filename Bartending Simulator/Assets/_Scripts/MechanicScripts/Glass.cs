using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    GlassNeeded glassNeeded;

    // Start is called before the first frame update
    void Start()
    {
        glassNeeded = GameObject.Find("Glasses").GetComponent<GlassNeeded>();
    }

    private void OnMouseDown() {
        glassNeeded.AddGlass(this.gameObject);
    }
}
