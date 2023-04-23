using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Behaviour : StateMachineBehaviour {

    //Declaration
    private GameObject player;
    private Transform playerPos;
    private Transform frontCheck;//Start potion for front raycast
    private Transform backCheck;//Start potion for back raycast
    private bool playerDetectedLeft;
    private bool playerDetectedRight;
    public float chaseSpeed;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        chaseSpeed = animator.gameObject.GetComponent<Enemy_Controller>().chaseSpeed;
        player = GameObject.FindGameObjectWithTag ("Player");
        frontCheck = animator.gameObject.transform.GetChild(1);
        backCheck = animator.gameObject.transform.GetChild(2);
        playerDetectedLeft = false;
        playerDetectedRight = false;
    
        if (player != null)
        {          
            playerPos = player.GetComponent<Transform>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

        Debug.DrawRay(frontCheck.transform.position, frontCheck.transform.right, Color.white);
        Debug.DrawRay(backCheck.transform.position, backCheck.transform.right, Color.red);
        
        //Creating raycasts
        RaycastHit2D hitInfoRight = Physics2D.Raycast(frontCheck.transform.position, frontCheck.transform.right, 6);
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(backCheck.transform.position, backCheck.transform.right, 6);

        

        if (player!=null)
        {

            //Checking left raycast detection
            if (hitInfoLeft.collider != null)
            {
                // Debug.Log(hitInfoLeft.collider.gameObject.tag);
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

                //Debug.Log(hitInfoRight.collider.gameObject.tag);
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
                //Move towards the player
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(playerPos.position.x, animator.transform.position.y), chaseSpeed * Time.deltaTime);
             
            }
            else
            {
                //Stop following
                animator.SetBool("IsFollowing", false);
            }
        }
        else
        {
                //Stop following
                animator.SetBool("IsFollowing", false);
        }
    }
}
