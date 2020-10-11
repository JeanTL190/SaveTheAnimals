using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Transform checkpoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if( (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<TeleportPlayer>().TeleportarPlayer(checkpoint);
        }
    }
}
