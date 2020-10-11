using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private float dashSpeedH;
    [SerializeField]
    private float dashSpeedV;
    private float dashTime;
    [SerializeField]
    private float startDashTime;
    [SerializeField]
    private float timeDashing;
    private PlayerWalk pw;
    private Rigidbody2D rb;

    void Start()
    {
        pw = GetComponent<PlayerWalk>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dashTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(pw.Dash(dashSpeedH, timeDashing,dashSpeedV));
                dashTime = startDashTime;
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
    }

}
