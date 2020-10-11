using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float force = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = this.transform.up*force;
        }
    }
}
