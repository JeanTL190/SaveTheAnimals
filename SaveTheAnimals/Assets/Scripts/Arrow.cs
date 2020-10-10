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

    void Start()
    {
        parent = gameObject.transform.parent.transform;
        GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed, 0);
    }
    
    void Update()
    {
        if(Mathf.Abs(Vector2.Distance(parent.position, gameObject.transform.position)) > distanceTravel)
        {
            Destroy(gameObject);
        }
    }
}
