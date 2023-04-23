using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot_Behaviour : StateMachineBehaviour {

    //Declarations
    private GameObject player;
    private Player_Controller playerScript;
    private Transform frontCheck;//Start potion for front raycast
    private Transform backCheck;//Start potion for back raycast
    private bool playerDetectedLeft = false;
    private bool playerDetectedRight = false;
    private EnemyWeapon_Controller enemyWeapon;
    private GameObject rangedEnemy;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rangedEnemy = animator.gameObject;
        frontCheck = animator.gameObject.transform.GetChild(1);
        backCheck = animator.gameObject.transform.GetChild(2);
       

        if (rangedEnemy != null)
        {
            enemyWeapon = rangedEnemy.GetComponent<EnemyWeapon_Controller>();
            //For reseting weapon cooldown
            enemyWeapon.Start();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.DrawRay(frontCheck.transform.position, frontCheck.transform.right, Color.red);
        Debug.DrawRay(backCheck.transform.position, backCheck.transform.right, Color.white);
        
        //Creating raycasts
        RaycastHit2D hitInfoRight = Physics2D.Raycast(frontCheck.transform.position, frontCheck.transform.right, 6);
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(backCheck.transform.position, backCheck.transform.right, 6);

      if(player!=null)
      {
            //Checking left raycast detection
            if (hitInfoLeft.collider != null)
            {
                if (hitInfoLeft.collider.CompareTag("Player"))
                {
                    playerDetectedLeft = true;
                    playerDetectedRight = false;
                    animator.gameObject.transform.Rotate(0f, 180f, 0f);
                }
                else
                {
                    playerDetectedLeft = false;
                }
            }
            else
            {
                playerDetectedLeft = false;
            }

            //Checking right raycast detection
            if (hitInfoRight.collider != null)
            {
                if (hitInfoRight.collider.CompareTag("Player"))
                {
                    playerDetectedRight = true;
                    playerDetectedLeft = false;
                }
                else
                {
                    playerDetectedRight = false;
                }
            }
            else
            {
                playerDetectedRight = false;
            }

            //Raycast has hit the player
            if (playerDetectedLeft == true || playerDetectedRight == true)
            {
                //Start shooting at the player
                enemyWeapon.shoot = true;
                
            }
            else
            {
                //Stop attacking
                enemyWeapon.shoot = false;
                animator.SetBool("IsFollowing", false);

            }
      }

      else
      {
          //Stop attacking
          enemyWeapon.shoot = false;
          animator.SetBool("IsFollowing", false);

      }

    }
}
