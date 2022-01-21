using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{
    public static void SaveInt(string name, int i) {
        PlayerPrefs.SetInt(name, i);
    }

    public static void SaveFloat(string name, float i) {
        PlayerPrefs.SetFloat(name, i);
    }

    public static int LoadInt(string name) {
        return PlayerPrefs.GetInt(name);
    }

    public static float LoadFloat(string name) {
        return PlayerPrefs.GetFloat(name);
    }


}
