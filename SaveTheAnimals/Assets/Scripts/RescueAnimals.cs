using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueAnimals : MonoBehaviour
{
    bool permit = false;
    bool fly = false;
    GameObject animal;
    Animator anim;
    [SerializeField] float speed = 5.0f;

    void Update()
    {
        if (permit && animal != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Aqui os animais desaparecem(sao salvos)
                StartCoroutine(Liberar());
            }
        }

        if (fly)
        {
            animal.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Animal"))
        {
            anim = other.gameObject.GetComponent<Animator>();
            permit = true;
            animal = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Animal"))
        {
            permit = false;
        }
    }

    IEnumerator Liberar()
    {
        anim.SetTrigger("Destrancou");
        animal.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Destrancou");
        yield return new WaitForSeconds(0.5f);
        animal.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Destrancou");
        fly = true;
        yield return new WaitForSeconds(3f);
        fly = false;
        animal.tag = "Untagged";
        Destroy(animal.transform.GetChild(0).gameObject);
    }
}
