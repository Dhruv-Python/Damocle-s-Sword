using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D core;
    public Rigidbody2D rb;
    public GameObject enemyBullet;
    public Transform enemyFirePoint;
    public float enemyBulletForce = 5f;
    float enemyNextTimeToFire = 2f;

     private void Start() {
          core = GameObject.Find("Core_Container").GetComponent<Rigidbody2D>();
     }

    void Update() 
    {
         if(Vector2.Distance(core.position, rb.position) < 2 && Time.time >= enemyNextTimeToFire)
         {
               enemyNextTimeToFire = Time.time + 2f;  
               EnemyBullet();
         } 
    }
     
    void FixedUpdate() 
    {
          Vector2 lookDir = rb.position - core.position;
          float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
          rb.rotation = angle + 180;  
    }

    void EnemyBullet()
    {
         float distance = Vector2.Distance(this.transform.position, core.transform.position);
         if (distance >= 2) return;

         GameObject bullet = Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);

         AudioManager.PlaySound("EnemyShoot_Sound");

         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
         rb.AddForce(enemyFirePoint.right * enemyBulletForce, ForceMode2D.Impulse);
         Destroy(bullet, 2f);
    }


}
