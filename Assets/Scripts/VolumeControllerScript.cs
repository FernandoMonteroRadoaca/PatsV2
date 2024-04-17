using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; // gallery of audio controllers

public class VolumeControllerScript : MonoBehaviour  
{
    [SerializeField] private AudioMixer audioMixer;
    public void MusicControl (float sliderMusic)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderMusic) * 20);
    }

}
