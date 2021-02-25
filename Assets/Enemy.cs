using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Trigger detected. Collision tag == " + collision.tag);
        if(collision.tag == "Projectile") {
            SendMessageUpwards("EnemyDestroyed");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
