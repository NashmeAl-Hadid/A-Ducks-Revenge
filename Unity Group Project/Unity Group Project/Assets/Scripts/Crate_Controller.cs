using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_Controller : MonoBehaviour {

    //Declarations
    public GameObject explodeEffect;
    private SpriteRenderer setSpriteRenderer;
    public int durability=100; // Crate health
    public GameObject healthPotion;
    public int crateDamage=100;
    public bool dropHealth=false; //Disabling/Enabling potion drop by crate 

    void Start ()
    {
        setSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Damaging Crate
    public void TakeDamage(int damage)
    {
        durability -= damage;
        //Flash Red
        StartCoroutine(Flash());

        if (durability <= 0)
        {
            Destroy();
        }
    }

    //Destroy crate
    public void Destroy()
    {
        //Play explosion sound
        OtherSound_Controller.OtherSound("ExplosionSound");
        //explosion effect
        Instantiate(explodeEffect, transform.position, transform.rotation);

        //Droping potion if true
        if (dropHealth==true)
        {
            var clone = Instantiate(healthPotion, transform.position, transform.rotation);
            //Potion jumps up when the crate is destroyed
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 4;
        }
        Destroy(gameObject);
    }

    IEnumerator Flash()
    {
        setSpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        setSpriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Damage enemies on hit
        if (collision.gameObject.tag.Equals("Enemy")|| collision.gameObject.tag.Equals("RangedEnemy"))
        {
            collision.gameObject.GetComponent<Enemy_Controller>().TakeDamage(crateDamage);
        }
    }
}
