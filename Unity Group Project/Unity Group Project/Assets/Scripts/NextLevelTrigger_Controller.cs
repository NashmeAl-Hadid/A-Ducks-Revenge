using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger_Controller : MonoBehaviour {
   
    //Declarations
    public string levelName;
    private Game_Master gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Reset Checkpoints
            gm.lastCheckPointPos = new Vector2(0, 0);
            //Reset picked gun
            gm.gunPicked = false;
            //Reset lever
            gm.leverActive = false;
            //Loading next level
            SceneManager.LoadScene(sceneName: levelName);
            Time.timeScale = 1f;
        }
    }
}
