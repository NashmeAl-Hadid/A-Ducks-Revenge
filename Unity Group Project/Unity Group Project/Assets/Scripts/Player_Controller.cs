using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

    
    

    private SpriteRenderer setSpriteRenderer;
    private float moveInputX;
    private Rigidbody2D rb;
    private bool facingRight=true;
    private bool isGrounded;
    private int extraJumps;
    private bool isClimbing;
    private Game_Master gm;

    public bool isJumping = false;
    public Health_Controller healthScript;
    public float ladderCheckDistance;
    public Button ladderButton;
    public Joystick_Controller joystick;
    public bool jumpClicked=false;
    public bool shootClicked=false;
    public bool ladderClicked = false;
    public float speed;
    public float climbSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;
    public int extraJumpsValue;
    public Animator animator;
    public Animator gunAnimator;
    public int health = 3;
    public GameObject deathEffect;

    
    //Button Functions

    public void LadderClicked()
    {
        ladderClicked = true;

    }

    public void LadderUnClicked()
    {
        ladderClicked = false;

    }

    public void Jump()
    {

        if ( extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            PlayerSound_Controller.PlayerSound("JumpSound");
            extraJumps--;
            jumpClicked = false;


        }
        else if (extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            PlayerSound_Controller.PlayerSound("JumpSound");
            jumpClicked = false;

        }
    }



    void Start()
    {
        health = 3;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        setSpriteRenderer = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        
        //If checkpoint is reached 
        if (gm.lastCheckPointPos!= new Vector2(0,0))
        {
            transform.position = gm.lastCheckPointPos;
        }
       


    }

    void Update()
    {
        //Changing player animator conditions accordingly
        animator.SetFloat("Run", Mathf.Abs(moveInputX));
        animator.SetBool("Grounded", isGrounded);
        //Creating raycast for detecting ladder
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderCheckDistance, whatIsLadder);

        //Checking player touching the ground
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            isJumping = false;
        }

        if (isGrounded == false)
        {         
            isJumping = true;          
        }

        //Checking if gun is picked and then applying the animator conditions accordingly
        if(transform.GetChild(1).gameObject.activeSelf)
        {

            gunAnimator.SetFloat("PlayerMove", Mathf.Abs(moveInputX));
            gunAnimator.SetBool("PlayerGrounded", isGrounded);
        }

        

        //Checking for ladder
        if (hitInfo.collider != null)         
        {
            ladderButton.gameObject.SetActive(true);
            if (ladderClicked ==true)
            {
                isClimbing = true;               
            }
        }
        else
        {
            isClimbing = false;
            ladderButton.gameObject.SetActive(false);
        }

        //Enabling the weapon script if gun is picked
        if(gm.gunPicked==true)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            this.gameObject.GetComponent<Weapon_Controller>().enabled = true;          
        }

       
        

    }




    void FixedUpdate()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
        moveInputX = joystick.Horizontal();
        animator.SetBool("Climbing", isClimbing);

        rb.velocity = new Vector2(speed * moveInputX, rb.velocity.y);



        if (isClimbing == true)
        {

            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1.5f;
        }


       

        if(facingRight==false&&moveInputX>0)
        {
            Flip();
        }
        else if(facingRight == true && moveInputX < 0)
        {
            Flip();
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if(collision.gameObject.tag.Equals("Spike"))
        {
            rb.velocity = Vector2.up * 6;
            TakeDamage(1);
           
        }

        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("RangedEnemy"))
        {
            rb.velocity = Vector2.up* 4;
            TakeDamage(1);
           
        }

        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            TakeDamage(1);

        }

        if (collision.gameObject.tag.Equals("HealthPotion"))
        {
            //Potion sound
            OtherSound_Controller.OtherSound("PotionSound");
            healthScript.numOfHearts += 1;
            Destroy(collision.gameObject);
        }

       
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            PlayerSound_Controller.PlayerSound("PickUpSound");
            transform.GetChild(1).gameObject.SetActive(true);
            this.gameObject.GetComponent<Weapon_Controller>().enabled = true;
            Destroy(collision.gameObject);
            gm.gunPicked = true;

        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Enemy")|| collision.gameObject.tag.Equals("RangedEnemy"))
        {
            rb.velocity = Vector2.up * 4;
           

        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        PlayerSound_Controller.PlayerSound("PlayerDamageSound");
        StartCoroutine(Flash());
        healthScript.numOfHearts = health;
    }

    IEnumerator Flash()
    {
        setSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        setSpriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.2f);
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
       // gameObject.SetActive(false);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


}

