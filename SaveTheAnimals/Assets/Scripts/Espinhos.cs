using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Transform checkpoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            collision.GetComponent<TeleportPlayer>().TeleportarPlayer(checkpoint);
        }
    }

}
