using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private GameManager gm;
    private bool destruiu = false;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && (((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            destruiu = true;
        }
    }
    private void LateUpdate()
    {
        if (destruiu)
        {
            destruiu = false;
            gm.Spawn();
        }
    }
}
