using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerController : MonoBehaviour
{
    private static MusicPlayerController _instance;
    public static MusicPlayerController Instance {get { return _instance; }}

    public enum Command {Silent, PlayOneTrack, PlayTwoTracks}

    [Header ("Which command to use at the start of specific scene")]
    public Command[] sceneCommand;
    [Header ("Which starting track to use at the start of a scene")]
    public int[] startTrack;
    public AudioClip[] audioTracks;

    private AudioSource audioSource;
    private int calledTrack;

    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
        if(!audioSource) {
            audioSource = GetComponent<AudioSource>();
        }
        if(SceneManager.GetActiveScene().name == "Game1"){
            PlayTwoTracks(0);
        }
    }

    // Start is called before the first frame update
    void Start() {
        DontDestroyOnLoad(this);
        if(sceneCommand[SceneManager.GetActiveScene().buildIndex] == Command.PlayOneTrack) {
            PlayLoop(startTrack[SceneManager.GetActiveScene().buildIndex]);
        } else if(sceneCommand[SceneManager.GetActiveScene().buildIndex] == Command.PlayTwoTracks) {
            PlayTwoTracks(startTrack[SceneManager.GetActiveScene().buildIndex]);
        } else if(sceneCommand[SceneManager.GetActiveScene().buildIndex] == Command.Silent) {
            Stop();
        }
    }

    public void PlaySong(int songInt){
        audioSource.clip = audioTracks[songInt];
        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayLoop(){
        audioSource.clip = audioTracks[calledTrack+1];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayLoop(int songInt) {
        audioSource.clip = audioTracks[songInt];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayTwoTracks(int songInt) {
        PlaySong(songInt);
        Invoke("PlayLoop",audioTracks[songInt].length);
    }

    public void Stop() {
        audioSource.Stop();
    }
}
