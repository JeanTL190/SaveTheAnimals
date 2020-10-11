using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public float velMultiplier;
    float normalMax;
    PlayerWalk pw;

    private void Start()
    {
        pw = GetComponent<PlayerWalk>();
        normalMax = pw.GetVelMax();
    }

    void PlayerSlide()
    {
        float velMax = normalMax * velMultiplier;
        pw.SetVelMax(velMax);
    }

    void ExitSlide()
    {
        pw.SetVelMax(normalMax);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slippery"))
        {
            PlayerSlide();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slippery"))
        {
            ExitSlide();
        }
    }

}
