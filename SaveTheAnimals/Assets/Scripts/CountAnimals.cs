using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountAnimals : MonoBehaviour
{
    GameObject[] animals;
    [SerializeField] GameObject panel;
    
    void Update()
    {
        animals = GameObject.FindGameObjectsWithTag("Animal");
        GetComponent<TextMeshProUGUI>().text = "Locked animals: " + animals.Length;

        if(animals.Length <= 0)
        {
            panel.SetActive(true);
        }

    }
}
