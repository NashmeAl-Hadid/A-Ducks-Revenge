using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Behaviour : StateMachineBehaviour
{
    //Declarations 
    private float speed;
    private Transform groundDetection;
    private Rigidbody2D rb;
    private int direction;
    private string tag;
    private GameObject player;
    private float rayDistance;
    private bool playerJumping;
    private Transform frontCheck;
    private Transform backCheck;
    private bool playerDetectedLeft = false;
    private bool playerDetectedRight = false;
    private bool patrolArea;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        speed = animator.gameObject.GetComponent<Enemy_Controller>().speed;
        tag = animator.gameObject.GetComponent<Enemy_Controller>().patrolTag;
        player = GameObject.FindGameObjectWithTag("Player");
        playerDetectedLeft = false;
        playerDetectedRight = false;
        groundDetection = animator.gameObject.transform.GetChild(0);
        frontCheck = animator.gameObject.transform.GetChild(1);
        backCheck = animator.gameObject.transform.GetChild(2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.DrawRay(frontCheck.transform.position, frontCheck.transform.right);
        Debug.DrawRay(backCheck.transform.position, backCheck.transform.right, Color.red);
        Debug.DrawRay(groundDetection.position, Vector2.down);

        //Creating raycasts
        RaycastHit2D hitInfoRight = Physics2D.Raycast(frontCheck.transform.position, frontCheck.transform.right, 6);
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(backCheck.transform.position, backCheck.transform.right, 6);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 6);

        rb.velocity = animator.transform.right * speed;

        
            //Changing direction when reaching end of patrolling ground
            if (!groundInfo.transform.gameObject.tag.Equals(tag))
            {
                animator.transform.Rotate(0f, 180f, 0f);
            }
        

       

        if (player != null)
        { 

             //Checking left raycast detection
                if (hitInfoLeft.collider != null)
                {
                    if (hitInfoLeft.collider.gameObject.tag.Equals("Player"))
                    {
                        playerDetectedLeft = true;
                        playerDetectedRight = false;
                    }
                    else
                    {
                        playerDetectedLeft = false;
                    }
                }

                //Checking right raycast detection
                if (hitInfoRight.collider != null)
                {
                    if (hitInfoRight.collider.gameObject.tag.Equals("Player"))
                    {
                        playerDetectedRight = true;
                        playerDetectedLeft = false;
                    }
                    else
                    {
                        playerDetectedRight = false;
                    }
                }

                //Raycast has hit the player
                if (playerDetectedLeft == true || playerDetectedRight == true)
                {
                   // playerJumping = playerScript.isJumping;

                   // if (playerJumping == false)
                   // {
                        animator.SetBool("IsFollowing", true);
                        animator.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                        
                   // }
                   // else
                   // {
                      //  animator.SetBool("IsFollowing", false);
                   // }
                }
         }
        else
        {
            animator.SetBool("IsFollowing", false);
        }







    }
}
