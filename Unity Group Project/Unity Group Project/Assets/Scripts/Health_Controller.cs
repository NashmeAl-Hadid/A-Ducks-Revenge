using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Controller : MonoBehaviour {

    //Declarations
    private int health;
    private GameObject player;
    private Player_Controller playerScript;
    public int numOfHearts;
    public Image[] hearts;
    public Canvas youDiedCanvas;
   

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player_Controller>();     
    }

    void Update()
    {   
        if(player!=null)
        {
           health = playerScript.health;

           if (health > numOfHearts)
           {
              health = numOfHearts;
           }

           if (numOfHearts == 0)
           {
               playerScript.Die();
                OtherSound_Controller.OtherSound("YouDiedSound");
                StartCoroutine(DeathScreen());     
           }

            for (int i = 0; i < hearts.Length; i++)
            {
              if (i < numOfHearts)
              {
                  hearts[i].enabled = true;
              }
              else
              {
                  hearts[i].enabled = false;
              }
            }
        }
    }

    //Reset game few seconds after deathscreen
    IEnumerator DeathScreen()
    {
        youDiedCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        youDiedCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
