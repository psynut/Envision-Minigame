using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private float volume = 0;

    void Update() {
        Debug.Log(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "Game1") {
            Slider volumeSlider = GameObject.FindGameObjectWithTag("GameController").GetComponent<Slider>();
            Debug.Log("Slider Value set to: " + volume);
            volumeSlider.value = volume;
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void AdjustVolume(float input) {
        volume = input;
    }
    
}
