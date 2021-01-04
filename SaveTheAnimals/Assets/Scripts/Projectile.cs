using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start ()
    {
        Destroy(this.gameObject, 3f);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        // Handles the multiple things the projectile can collide with
        // Walls, enemies, etc.
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject, 0.05f);
            }
            if (collision.gameObject.CompareTag("Block"))
            {
                Destroy(this.gameObject, 0.05f);
            }
        }
    }
}
