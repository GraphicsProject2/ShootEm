using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/* This class allows the user to control the volume of the
 * background music using the slider in option menu
 */
public class VolumeController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audio;


    void Start()
	{
        // Initialize the volume
        if (PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            slider.value = 0.8f;
        }
        audio.volume = slider.value;

        // Adds a listener to detect when the slider is moved
        slider.onValueChanged.AddListener(SetVolume);
    }

    // Sets the volume based on the slider
    public void SetVolume(float volume)
    {
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
