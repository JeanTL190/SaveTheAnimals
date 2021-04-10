using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider mSlider;
    public Slider sSlider;

    public GameObject menu;
    public static bool menuOpen = false;

    void Start()
    {
        mSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (menuOpen)
            {
                menu.SetActive(false);
                menuOpen = false;
            } else
            {
                menu.SetActive(true);
                menuOpen = true;
            }
        }
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSFXLevel(float sliderValue)
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }
}
