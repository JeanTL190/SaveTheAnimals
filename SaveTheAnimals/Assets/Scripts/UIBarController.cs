using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarController : MonoBehaviour
{
    private Slider slider;

    private void Awake ()
    {
        slider = GetComponent<Slider>();
    }

    public float sliderValue
    {
        set
        {
            slider.value = value;
        }

        get
        {
            return slider.value;
        }
    }
}