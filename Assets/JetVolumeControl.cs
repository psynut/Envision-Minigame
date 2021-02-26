using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetVolumeControl : MonoBehaviour
{
    private AudioSource musicPC;

    // Start is called before the first frame update
    void Start()
    {
        musicPC = FindObjectOfType<MusicPlayerController>().GetComponent<AudioSource>();
        if(musicPC == null) {
            Debug.LogWarning("No MusicPlayerController Found - Volume set to 0");
            GetComponent<AudioSource>().volume = 0f;
        } else {
            GetComponent<AudioSource>().volume = musicPC.volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
