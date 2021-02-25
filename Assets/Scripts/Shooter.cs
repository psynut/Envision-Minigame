using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileParent;
    public float speed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Fire();
        }
    }

    public void Fire() {
        GameObject m_projectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity, projectileParent) as GameObject;
        m_projectile.transform.eulerAngles = new Vector3(0,0,90);
        m_projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
    }
}
