using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private float forca = 15f;
    private float dashTime;
    [SerializeField]
    private float startDashTime = 0.6f;
    [SerializeField]
    private float timeDashing = 0.2f;
    private PlayerWalk pw;
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject objectGroundCheck;
    private GroundCheck scriptGroundCheck;

    public bool canDash = false;

    void Awake()
    {
        objectGroundCheck = GameObject.Find("GroundCheck");
    }

    void Start()
    {
        
        pw = GetComponent<PlayerWalk>();
        rb = GetComponent<Rigidbody2D>();
        scriptGroundCheck = objectGroundCheck.GetComponent<GroundCheck>();
    }

    void Update()
    {
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
        }
        else if (scriptGroundCheck.isGrounded)
        {
            canDash = true;
        }
        

        if (Input.GetKeyDown(KeyCode.LeftShift)  && canDash )
        {
            StartCoroutine(pw.Dash(timeDashing,forca));
            dashTime = startDashTime;
            canDash = false;
        }
    }

    bool GetDash()
    {
        return canDash;
    }
}