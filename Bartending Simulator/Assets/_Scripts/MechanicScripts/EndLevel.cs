using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTicket() {
        // Ticket 
    }

    public void GoodEnding() {
        // 

    }

    public void BadEnding() {
        // Ask to restart Level or Menu
        // TO DO - Set up buttons & call functions below
    }

    public void Menu() {
        // Load Menu Scene
        SceneManager.LoadScene(0);
    }
    public void RestartLevel() {
        // Reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
