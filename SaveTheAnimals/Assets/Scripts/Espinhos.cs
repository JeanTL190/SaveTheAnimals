using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Transform checkpoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu "+ collision.gameObject.layer, collision.gameObject);
        
        if( (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            Debug.Log("Entrou no if");
            collision.gameObject.GetComponent<TeleportPlayer>().TeleportarPlayer(checkpoint);
        }
    }
}
