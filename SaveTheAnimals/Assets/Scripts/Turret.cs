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

    [SerializeField]
    private float projectileSpeed = 10f;

    private GameObject player;

    private GameObject newArrow;
    private bool canFire = false;

    private Sounds sounds;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeBetweenArrows = startTime;
        sounds = GetComponent<Sounds>();
    }

    void Update()
    {
        if (canFire)
        {
            if (timeBetweenArrows <= 0)
            {
                SpawnArrow();
                timeBetweenArrows = startTime;
            }
            else
            {
                timeBetweenArrows -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in range!");
            canFire = true;
        }
        
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player outside range!");
            canFire = false;
        }
        
    }

    void SpawnArrow ()
    {
        Arrow arrowObj;
        float arrowRotation = (Mathf.Atan2((player.transform.position.x - this.transform.position.x), (player.transform.position.y - this.transform.position.y)) * Mathf.Rad2Deg - 90f);
        // newArrow = Instantiate(arrow, arrowShooter.position, Quaternion.identity * Quaternion.Euler(0f, 0f, arrowRotation - 180f));
        newArrow = Instantiate(arrow, arrowShooter.position, Quaternion.identity);
        arrowObj = newArrow.GetComponent<Arrow>();
        arrowObj.FireDirection(Vector3.Normalize(player.transform.position - newArrow.transform.position) * projectileSpeed);
        sounds.StartSom(0);
        
    }
}
