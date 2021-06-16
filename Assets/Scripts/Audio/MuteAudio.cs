using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MuteAudio : MonoBehaviour
{
    [SerializeField] string sliderTag;
    [SerializeField] bool muteAudio;

    [SerializeField] List<AudioSource> sliders;

    Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();

        foreach (var slider in GameObject.FindGameObjectsWithTag(sliderTag))    // Get all the sliders in the scene with the given gameObject Tag,
        {                                                                       // you can have more than one if you want to control for example the SFX without impacting the Backgroung volume
            sliders.Add(slider.GetComponent<AudioSource>());
        }

        if (PlayerPrefs.GetInt($"{sliderTag} toggle") == 1) toggle.isOn = true;        // Simple way to set the toggle to be on or not based on what was the last value saved
        else if (PlayerPrefs.GetInt($"{sliderTag} toggle") == 0) toggle.isOn = false;

        Debug.Log(PlayerPrefs.GetInt($"{sliderTag} toggle"));
    }

    void Update()
    {
        muteAudio = toggle.isOn;

        foreach (var slider in sliders)
        {
            if (muteAudio)
            {
                slider.GetComponent<AudioSource>().mute = true;
                PlayerPrefs.SetInt($"{sliderTag} toggle", 1);
            }
            else
            {
                slider.GetComponent<AudioSource>().mute = false;
                PlayerPrefs.SetInt($"{sliderTag} toggle", 0);
            }
        }
    }
}
