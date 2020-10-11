using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField]
    private float dashSpeedH;
    [SerializeField]
    private float dashSpeedV;
    private float dashTime;
    [SerializeField]
    private float timeDashing;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((((1 << collision.gameObject.layer) & platformLayerMask) != 0))
        {
            StartCoroutine(collision.gameObject.GetComponent<PlayerWalk>().Trampolim(dashSpeedH, timeDashing, dashSpeedV));
        }
    }
}
