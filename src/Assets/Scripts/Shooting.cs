using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static float firerate = 2; 
    [SerializeField] bool isBossMode;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float fireRate;

    float bulletForce = 10f;
    float NextTimeToFire;

    private void Start()
    {
        if (isBossMode)
        {
            fireRate = firerate * 1.5f;
        }
        else
        {
            fireRate = firerate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossMode)
        {
            fireRate = firerate * 1.5f;
        }
        else
        {
            fireRate = firerate;
        }

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        { 
            NextTimeToFire = Time.time + 1/fireRate;
            ShootBullet();
        }

    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioManager.PlaySound("turrentShoot_Sound");
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
    }

}
