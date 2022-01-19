using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosses : MonoBehaviour
{
    [SerializeField] GameObject[] crosses;
    public static int index = 0;

    [SerializeField] GameObject restart;

    // Start is called before the first frame update
    void Start() {
        crosses[0].SetActive(false);
        crosses[1].SetActive(false);
        crosses[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 1) {
            crosses[0].SetActive(true);
            crosses[1].SetActive(false);
            crosses[2].SetActive(false);
        } else if (index == 2) {
            crosses[0].SetActive(true);
            crosses[1].SetActive(true);
            crosses[2].SetActive(false);
        } else if (index == 3) {
            crosses[0].SetActive(true);
            crosses[1].SetActive(true);
            crosses[2].SetActive(true);
            restart.SetActive(true);
            Timer.timer = 0.0f;
            // End Game Condition
        }
    }
}
