using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform arrowShooter;
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private float startTime;
    private float timeBetweenArrows;

    void Start()
    {
        timeBetweenArrows = startTime;
    }

    void Update()
    {
        if(timeBetweenArrows <= 0)
        {
            Instantiate(arrow, arrowShooter.position, Quaternion.identity, gameObject.transform);
            timeBetweenArrows = startTime;
        }else
        {
            timeBetweenArrows -= Time.deltaTime;
        }
    }
}
