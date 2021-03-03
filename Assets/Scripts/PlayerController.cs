using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(0,-h,v)* sensitivity * Time.deltaTime);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x,0.1f,0.2f);
        pos.y = Mathf.Clamp(pos.y,0.1f,0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
