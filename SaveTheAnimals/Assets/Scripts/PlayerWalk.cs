using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float velMax = 1f;
    [SerializeField] private string ipt;
    [SerializeField] private bool right = true;
    private Rigidbody2D rb;
    private float vel;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vel = velMax;
    }
    private void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    private void FixedUpdate()
    {
        float aux = Input.GetAxis(ipt);
        if (aux > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = new Vector2(vel, rb.velocity.y);
            right = true;
        }
        else if (aux < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            right = false;
        }
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public bool GetRight()
    {
        return right;
    }
    public void ResetVel()
    {
        vel = velMax;
    }
    public void ZeroVel()
    {
        vel = 0;
    }
    public void SetVelMax(float v)
    {
        velMax = v;
    }

}
