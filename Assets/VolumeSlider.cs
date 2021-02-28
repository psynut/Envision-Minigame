using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    private Slider slider;
    private AudioSource[] audioSources;
    private static VolumeSlider _instance;
    public static VolumeSlider Instance {get {return _instance;}}


    void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = VolumeController.GetMasterVolume();
        audioSources = FindObjectsOfType<AudioSource>();
        AdjustVolume(VolumeController.GetMasterVolume());
    }

    void AdjustVolume(float volume) {
        VolumeController.SetMainVolume(volume);
        foreach(AudioSource audioSource in audioSources) {
            audioSource.volume = volume;
        }
    }
}
