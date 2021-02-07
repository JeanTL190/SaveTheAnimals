using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFire : MonoBehaviour
{
    [SerializeField]
    private GameObject energyBarUI;

    private void Start ()
    {
        GameObject.Find("Player").GetComponent<PlayerFire>().canFire = false;
        energyBarUI.SetActive(false);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerFire>().canFire = true;
            energyBarUI.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
