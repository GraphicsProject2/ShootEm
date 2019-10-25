using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audio;


    void Start()
	{
        if (PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            slider.value = 0.8f;
        }
        audio.volume = slider.value;
        slider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
