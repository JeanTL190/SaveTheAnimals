using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueAnimals : MonoBehaviour
{
    bool permit = false;
    GameObject animal;

    void Update()
    {
        if (permit && animal != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Aqui os animais desaparecem(sao salvos)
                Destroy(animal);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Animal"))
        {
            permit = true;
            animal = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Animal"))
        {
            permit = false;
            animal = null;
        }
    }
}
