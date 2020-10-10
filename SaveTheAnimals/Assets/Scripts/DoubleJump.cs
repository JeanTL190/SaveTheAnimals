using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private int jumpExtra = 1;
    private bool canDoubleJump = false;
    private PlayerJump pj;
    private Rigidbody2D rb;
    private Animator anim;
    private int jumps = 0;

    private void Awake()
    {
        pj = GetComponent<PlayerJump>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (pj.IsGrounded())
        {
            canDoubleJump = true;
            jumps = 0;
        }
        PuloDuplo();

    }
    private void PuloDuplo()
    {
        if (Input.GetButtonDown("Jump") && !pj.IsGrounded() && canDoubleJump)
        {
            jumps++;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * pj.GetJumpForce(), ForceMode2D.Impulse);
            if(jumps==jumpExtra)
            {
                canDoubleJump = false;
            }
        }
    }
    public void SetJumpExtra(int j)
    {
        jumpExtra = j;
    }
}
