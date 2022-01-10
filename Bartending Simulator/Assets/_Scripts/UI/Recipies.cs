using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipies : MonoBehaviour
{
    int index = 0;
    [SerializeField]
    Texture[] textures;
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<RawImage>().texture = textures[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (index > 1) {
            index = 0;
        }

        if (index < 0) {
            index = 1;
        }

        GetComponent<RawImage>().texture = textures[index];
    }

    public void Button(int i) {
        if (i == 0) {
            index--;
        } else if (i == 1) {
            index++;
        }
    }
}
