using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet_Controller : MonoBehaviour {

    //Declarations
    public float speed;
    public int damage;
    private Rigidbody2D rb;
    public GameObject impactEffect;
  
      
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject,3);
    }

    void CreateImpactExplosion()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy_Controller enemy = collision.GetComponent<Enemy_Controller>();
        Crate_Controller crate = collision.GetComponent<Crate_Controller>();

        // Damage enemy if shot
        if (enemy!=null)
        {
            enemy.TakeDamage(damage);
        }

        // Damage crate if shot
         if(crate!=null)
        {
            crate.TakeDamage(damage);
        }
         //Destroy potion if shot
        if (collision.gameObject.tag.Equals("HealthPotion"))
        {

            Destroy(collision.gameObject);
        }

        //Ignore collision
        if (!collision.gameObject.tag.Equals("EnemyBullet")&& !collision.gameObject.tag.Equals("Coin") && !collision.gameObject.tag.Equals("Ladder"))
        {
            CreateImpactExplosion();
            Destroy(gameObject);

        }
        
    }

    

}
