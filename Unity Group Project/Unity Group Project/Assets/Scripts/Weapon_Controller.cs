using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour {

    //Declarations
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ImpactEffect;
    public GameObject player;
    public GameObject muzzleFlash;
    public float fireRate;
    private float fireCooldown;
    private bool shootClicked = false;


    //Button Functions

    public void ShootClickPressed()
    {
        shootClicked = true; 

    }

    public void ShootClickReleased()
    {
        shootClicked = false;
    }

   
    void Start()
    {
        fireCooldown = fireRate;   
    }


    void Update ()
    {
        if(fireCooldown>0)
        {
            fireCooldown -= Time.deltaTime;
        }      

        if (shootClicked==true & fireCooldown<=0)
        {
            StartCoroutine(MuzzleFlash());
            Shoot();
            fireCooldown = fireRate;
        }
	}

    IEnumerator MuzzleFlash()
    {
        var clone = Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
        clone.transform.parent = gameObject.transform;
        yield return new WaitForSeconds(0.1f);
        Destroy(clone);
    }

    void Shoot()
    {    
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        PlayerSound_Controller.PlayerSound("ShotSound");
    }

   
}
