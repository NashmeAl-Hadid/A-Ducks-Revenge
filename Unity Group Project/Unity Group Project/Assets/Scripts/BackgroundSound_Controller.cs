using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound_Controller : MonoBehaviour {

   
    private static BackgroundSound_Controller instance;


    void Awake()
    {
        
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(gameObject);
        }


    }
}
