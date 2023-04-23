using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_Behaviour : StateMachineBehaviour {

    //Declarations
    private GameObject player;
    private Transform frontCheck;
    private Transform backCheck;
    private bool playerDetectedLeft;
    private bool playerDetectedRight;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        frontCheck = animator.gameObject.transform.GetChild(1);
        backCheck = animator.gameObject.transform.GetChild(2);
        playerDetectedLeft = false;
        playerDetectedRight = false;
        player = GameObject.FindGameObjectWithTag("Player");     
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.DrawRay(frontCheck.transform.position, frontCheck.transform.right, Color.white);
        Debug.DrawRay(backCheck.transform.position, backCheck.transform.right, Color.red);
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
                animator.SetBool("IsFollowing", true);

            }

            else
            {
                animator.SetBool("IsFollowing", false);
            }
        }
        else
        {
            animator.SetBool("IsFollowing", false);
        }
    }
}
