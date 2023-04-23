using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume_Master : MonoBehaviour
{

    public AudioMixer Mixer;

    public void SetLevel(float sliderValue)
    {
        Mixer.SetFloat("SoundParam", Mathf.Log10(sliderValue) * 20);
    }

}