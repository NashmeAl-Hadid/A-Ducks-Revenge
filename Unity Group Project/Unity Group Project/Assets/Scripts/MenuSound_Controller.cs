using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound_Controller : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (GameObject.FindGameObjectWithTag("LevelSound") != null)
        {
            audioSource.Stop();
        }
    }

}
