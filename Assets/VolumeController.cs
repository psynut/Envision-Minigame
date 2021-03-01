using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    const string MAIN_VOLUME_KEY = "master_volume";

    public static void SetMainVolume(float volume) {
        if(volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MAIN_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Main volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MAIN_VOLUME_KEY);
    }
}
