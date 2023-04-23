using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {
   
    //Declarations
    public int health = 100;
    public GameObject deathEffect;  
    public bool facingLeft; //true left and false right
    public string patrolTag; //Which object is enemy patrolling on
    public float speed=2;// if enemy is a patrolling type;
    public float chaseSpeed=2; //If enemy is a follwing type
    private SpriteRenderer setSpriteRenderer;
    private string tagName;
    void Start()
    {
        setSpriteRenderer = GetComponent<SpriteRenderer>();
        
        //Assign direction of the enemy accroding to the sprite rotation
        if (transform.rotation.y == 0)
        {
            facingLeft = false;
        }
        else
        {
            facingLeft = true;
        }
    }

    //Enemy gets damaged
    public void TakeDamage(int damage)
    {
        health -= damage;
        //Flash Red
        StartCoroutine(Flash());
        //Play enemy damage sound
        EnemySound_Controller.EnemySound("EnemyDamageSound");
        if (health<=0)
        {
            Die();
        }

    }

    //Checking which object is enemy patrolling on and killing enemy when it hits the spikes
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        tagName = collision.gameObject.tag;

        switch (tagName)
        {
            case "Ground":
                patrolTag = "Ground";
                break;

            case "Platform":
                patrolTag = "Platform";
                break;

            case "Corner":
                patrolTag = "Corner";
                break;
            case "Spike":
                Die();
                break;
        }



    }

    IEnumerator Flash()
    {        
            setSpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            setSpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.2f);    
    }

    //Destroy Enemy
    void Die()
    {
        //Play explosion sound
        EnemySound_Controller.EnemySound("ExplosionSound");
        //Death effect
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
