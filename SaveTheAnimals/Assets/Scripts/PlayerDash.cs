using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    private float dashForce;
    private Vector2 dashDir;
    private float dashTime;
    [SerializeField]
    private float verticalDampening;
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
        player = this.gameObject;
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

        if (Input.GetKeyDown(KeyCode.Mouse1) && canDash)
        {
            dashDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
            dashDir.Normalize();
            dashDir *= dashForce;
            dashDir.y *= verticalDampening;
            StartCoroutine(pw.Dash(timeDashing, dashDir));
            dashTime = startDashTime;
            canDash = false;
        }
    }
}