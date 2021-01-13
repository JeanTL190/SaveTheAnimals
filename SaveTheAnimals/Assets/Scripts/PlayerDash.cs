﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private float forca;
    private float dashTime;
    [SerializeField]
    private float startDashTime;
    [SerializeField]
    private float timeDashing;
    private PlayerWalk pw;
    private Rigidbody2D rb;

    public bool canDash = true;

    void Start()
    {
        pw = GetComponent<PlayerWalk>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dashTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(pw.Dash(timeDashing,forca));
                dashTime = startDashTime;
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
    }

}
