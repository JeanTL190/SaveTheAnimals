using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float arrowSpeed;
    private Transform parent;
    [SerializeField]
    private float distanceTravel;

    private Rigidbody2D body;

    private void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    public void FireDirection (Vector2 direction)
    {
        body.AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Sounds>().StartSom(2);
            collision.gameObject.GetComponent<TeleportPlayer>().TeleportarPlayer();
        }

        if (collision.CompareTag("Block"))
        {
            Destroy(this.gameObject);
        }
    }
}
