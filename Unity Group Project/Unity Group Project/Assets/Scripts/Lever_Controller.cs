using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Controller : MonoBehaviour {

    //Declarations
    private Animator leverAnim;
    private Animator gateAnim;
    public GameObject nextLevelTrigger;
    private Game_Master gm;

    void Start ()
    {
        leverAnim = GetComponent<Animator>();
        gateAnim = GameObject.FindGameObjectWithTag("Gate").GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();

        //If is already activated according to the game master
        if(gm.leverActive==true)
        {
            //Pull lever
            leverAnim.SetBool("Active", true);
            gm.leverActive = true;
            //Open gate
            gateAnim.SetBool("Active", true);
            //Active next level transition
            nextLevelTrigger.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            //Lever sound
            OtherSound_Controller.OtherSound("LeverSound");
            //Pull lever
            leverAnim.SetBool("Active", true);
            gm.leverActive = true;
            //Open gate
            gateAnim.SetBool("Active", true);  
            //Active next level transition
            nextLevelTrigger.SetActive(true);
            
        } 
    }  
}
