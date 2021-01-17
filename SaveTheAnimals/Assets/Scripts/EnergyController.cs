using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private GameObject energyBar;
    [SerializeField] float maxEnergy = 100f;

    private float energy;
    private UIBarController barController;

    private void Awake ()
    {
        energy = maxEnergy;
        barController = energyBar.GetComponent<UIBarController>();
    }

    private void Update ()
    {
        barController.sliderValue = energy;
    }

    public float GetEnergy ()
    {
        return energy;
    }

    public void ChangeEnergy (float value)
    {
        energy += value;
        if (energy > 100f)
            energy = 100f;
    }
}
