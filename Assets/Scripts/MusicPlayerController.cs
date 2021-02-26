using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour
{
    private static MusicPlayerController _instance;
    public static MusicPlayerController Instance {get { return _instance; }}

    public AudioClip[] audioTracks;

    private AudioSource audioSource;
    private int calledTrack;

    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if(!audioSource) {
            audioSource = GetComponent<AudioSource>();
        }
        PlayTwoTracks(0);
    }

    public void PlaySong(int songInt){
        audioSource.clip = audioTracks[songInt];
        audioSource.Play();
    }

    public void PlayLoop(){
        audioSource.clip = audioTracks[calledTrack+1];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayTwoTracks(int songInt) {
        calledTrack = songInt;
        audioSource.clip = audioTracks[songInt];
        audioSource.Play();
        Invoke("PlayLoop",audioTracks[songInt].length);
    }

    public void Stop() {
        audioSource.Stop();
    }

    public void AdjustVolume(float input) {
        Debug.Log("AdjustVolume to: " + input);
        audioSource.volume = input;
    }
}
