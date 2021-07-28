using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider), typeof(AudioSource))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string SliderPlayerPrefName;
    AudioSource audioSource;
    Slider slider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey(SliderPlayerPrefName)) slider.value = PlayerPrefs.GetFloat(SliderPlayerPrefName); // Set the starting value to be the last one you have set
        else slider.value = float.MaxValue;
    }

    void Update()
    {
        audioSource.volume = slider.value; 

        PlayerPrefs.SetFloat(SliderPlayerPrefName, slider.value); //Save the current value 
    }
}
