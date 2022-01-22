using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadMainLevel() {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }
    public void LoadShop() {
        SceneManager.LoadScene(2);
    }
}
