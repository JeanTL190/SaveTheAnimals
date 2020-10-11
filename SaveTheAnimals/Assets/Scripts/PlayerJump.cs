using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private string GroundCheckName;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private Animator jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Pular();
        anim.SetFloat("SpeedUp", rb.velocity.y);
        anim.SetBool("Ground", IsGrounded());
    }
    public bool IsGrounded()
    {
        return transform.Find(GroundCheckName).GetComponent<GroundCheck>().isGrounded;
    }
    void Pular()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump.SetTrigger("NormalJump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    public float GetJumpForce()
    {
        return jumpForce;
    }
    public void SetJumpForce(float j)
    {
        jumpForce = j;
    }
}
