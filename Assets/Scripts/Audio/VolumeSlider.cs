using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider), typeof(AudioSource))]
public class VolumeSlider : MonoBehaviour
{
    AudioSource audioSource;
    Slider slider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey($"{gameObject.name} Slider")) slider.value = PlayerPrefs.GetFloat($"{gameObject.name} Slider"); // Set the starting value to be the last one you have set
        else slider.value = float.MaxValue;
    }

    void Update()
    {
        audioSource.volume = slider.value; 

        PlayerPrefs.SetFloat($"{gameObject.name} Slider", slider.value); //Save the current value 
    }
}
