using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaurelDance : MonoBehaviour
{
    public float speed = 0.002f;
    public float upLimit = 279.5f;
    public float downLimit = 270.5f;
    private bool backForth = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.Rotate(-speed,-(speed),0);
    }

    // Update is called once per frame
    void Update()
    {

        if(backForth == true) {
            gameObject.transform.Rotate(0,speed,0);
            if(gameObject.transform.localRotation.eulerAngles.y > upLimit) {
                backForth = false;
            }
        } else {
            gameObject.transform.Rotate(0, -speed,0);
            if(gameObject.transform.localRotation.eulerAngles.y < downLimit) {
                backForth = true;
            }
        }
    }
}
