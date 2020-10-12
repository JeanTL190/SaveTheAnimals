using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioSource [] audio;
    public void StartSom(int i)
    {
        if(audio[i]!=null && !audio[i].isPlaying)
            audio[i].Play();
    }
}
