using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public void OnOff(GameObject obj) {
        bool ison = obj.activeInHierarchy;
        obj.gameObject.SetActive(!ison);
    }

    public void AudioPlay(AudioSource audio) {
        audio.Play();
    }
        
    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
