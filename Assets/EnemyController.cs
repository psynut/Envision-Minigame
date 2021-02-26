using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Light sun;
    public MusicPlayerController musicPC;

    private Transform[] children;
    private float startChildCount;
    private int childCount;

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<Transform>();
        childCount = children.Length-1;

        startChildCount = childCount;

        sun.intensity = 0;
    }
    public void EnemyDestroyed() {
        childCount --;
        sun.intensity = (1-(childCount / startChildCount))*0.5f;
        if (childCount == 0){
            EndScene();
        }
    }

    private void EndScene() {
        musicPC.PlaySong(2);
        Invoke("LoadNextScene",7);
    }

    private void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
