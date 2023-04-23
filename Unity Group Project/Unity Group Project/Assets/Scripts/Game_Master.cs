using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Game_Master : MonoBehaviour {
    
    //Delarations
    private static Game_Master instance;
    public Vector2 lastCheckPointPos;
    public bool gunPicked;
    public int coinCollected;
    public bool leverActive;//Save lever state upon death

    void Awake ()
    {
        //Default values
        coinCollected = 0;
        gunPicked = false;
        leverActive = false;

        if (instance==null)
        {
            instance =this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }      
    }
}
