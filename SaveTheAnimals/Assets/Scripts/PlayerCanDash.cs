using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanDash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color newColor;
    [SerializeField] private PlayerDash playerdash;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        playerdash = GetComponent<PlayerDash>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(playerdash.canDash)
        {
            sr.color = Color.white;
        }
        else
        {
            sr.color = new Color(255, 0, 255, 100);
        }
    }
}
