using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon_Controller : MonoBehaviour
{
    //Declaration
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ImpactEffect;
    public GameObject rangedEnemy;
    public GameObject muzzleFlash;
    public float fireRate;
    public bool shoot;
    private float fireCooldown;

    public void Start()
    {
        fireCooldown = fireRate;
        shoot = false;
    }

    public void Update()
    {
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }

        if (shoot==true && fireCooldown <= 0)
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
        EnemySound_Controller.EnemySound("EnemyShot");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
