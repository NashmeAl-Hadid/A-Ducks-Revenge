using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Controller : MonoBehaviour {

    //Declaration
    public float speed;
    public int damage = 20;   
    public GameObject impactEffect;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void CreateImpactExplosion()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller player = collision.GetComponent<Player_Controller>();

        //Damage Player
        if (player != null)
        {
            player.TakeDamage(1);
        }

        //Don't collide with player bullet
        if (!collision.gameObject.tag.Equals("PlayerBullet"))
        {
               CreateImpactExplosion();
                Destroy(gameObject);
        }
    }

}
