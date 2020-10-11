using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField]
    private float forca;
    [SerializeField]
    private float timeDashing;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            StartCoroutine(collision.gameObject.GetComponent<PlayerWalk>().Trampolim(timeDashing,forca,transform.up));
        }
    }
    private void Start()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
    }
}
