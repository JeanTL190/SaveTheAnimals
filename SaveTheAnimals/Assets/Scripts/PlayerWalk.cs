using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] private float velMax = 1f;
    [SerializeField] private float acel = 1f;
    [SerializeField] private float desac = 1f;
    [SerializeField] private string ipt;
    [SerializeField] private bool right = true;
    private bool das = false;
    private Rigidbody2D rb;
    private float velAtual;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        velAtual = velMax;
    }
    private void Update()
    {
        if(!das)
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        else
        {
            anim.SetFloat("Speed", Mathf.Abs(0));
        }
        anim.SetBool("Dash", das);
    }
    private void FixedUpdate()
    {
        float aux = Input.GetAxis(ipt);
        if (!das)
        {
            if (aux > 0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                velAtual += (aux * acel);
                ClampVelocity(velAtual);
                right = true;
            }
            else if (aux < 0)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                velAtual += (aux * acel);
                ClampVelocity(velAtual);
                right = false;
            }
            else
            {
                Stoped();
                ClampVelocity(velAtual);
            }
        }  
    }
    private void ClampVelocity(float vel)
    {
        float x = Mathf.Clamp(vel, -velMax, velMax);
        rb.velocity = new Vector2(x, rb.velocity.y);
        velAtual = x;
    }
    private void Stoped()
    {
        if (velAtual != 0)
        {
            if (velAtual > 0)
            {
                velAtual -= desac;
                velAtual = Mathf.Clamp(velAtual, 0, velMax);
            }
            else if (velAtual < 0)
            {
                velAtual += desac;
                velAtual = Mathf.Clamp(velAtual, -velMax, 0);
            }
        }
    }
    public bool GetRight()
    {
        return right;
    }
    public void ResetVel()
    {
        velAtual = velMax;
    }
    public void ZeroVel()
    {
        velAtual = 0;
    }
    public void SetVelMax(float v)
    {
        velMax = v;
    }
    public float GetVelMax()
    {
        return velMax;
    }
    public IEnumerator Dash(float timeDashing, float forca)
    {
        das = true;
        rb.gravityScale = 1;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if(vertical!=0 && horizontal != 0)
        {
            rb.AddForce(new Vector2(horizontal, vertical).normalized * forca, ForceMode2D.Impulse);
        }
        else if (vertical != 0)
        {
            rb.AddForce(new Vector2(0, vertical).normalized * forca, ForceMode2D.Impulse);
        }
        else
        {
            if(right)
                rb.AddForce(Vector2.right * forca, ForceMode2D.Impulse);
            else
                rb.AddForce(Vector2.left * forca, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(timeDashing);
        das = false;
        rb.gravityScale = 3;
    }
    public IEnumerator Trampolim(float timeDashing, float forca, Vector3 v)
    {
        das = true;
        rb.gravityScale = 1;
        rb.velocity = Vector3.zero;
        rb.AddForce(v * forca, ForceMode2D.Impulse);
        yield return new WaitForSeconds(timeDashing);
        das = false;
        rb.gravityScale = 3;

    }
}
