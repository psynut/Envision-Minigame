using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public float maxLife = 10;

    private float awakeTime;

    // Start is called before the first frame update
    void Awake()
    {
        awakeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float m_age = Time.timeSinceLevelLoad - awakeTime;
        Debug.Log(m_age);
        if(m_age > 10) {
            Destroy(gameObject);
        }
    }
}
