using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountAnimals : MonoBehaviour
{
    GameObject[] animals;
    
    void Update()
    {
        animals = GameObject.FindGameObjectsWithTag("Animal");
        GetComponent<TextMeshProUGUI>().text = "Animais presos: " + animals.Length;
    }
}
