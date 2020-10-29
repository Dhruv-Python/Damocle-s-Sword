using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Rigidbody2D core;
    public Rigidbody2D rb;

    [SerializeField] GameObject missilePrefab;
    public Transform missileFirePoint;

    [SerializeField] GameObject fragPrefab;
    public Transform fragFirePoint;

    private float missileForce = 0.5f;
    private float fragForce = 0.5f;

    float enemyNextTimeToFire = 0f;

    float distance;

     void Start()
     {
        core = GameObject.Find("Core_Container").GetComponent<Rigidbody2D>();
     }

    void Update() 
    {
        distance = Vector2.Distance(this.transform.position, core.transform.position);
        if(Time.time >= enemyNextTimeToFire && distance <= 4.5)
        {
            enemyNextTimeToFire = Time.time + 3f;
            AudioManager.PlaySound("BossShoot_Sound");
            bool isMissile = (Random.value > 0.5f);
            if(isMissile)
            {
                ShootMissile();
            }
            else
            {
                ShootFrag();
            }
        } 
    }
     
    void FixedUpdate() 
    {
        // Boos looks at the core
        Vector2 lookDir = rb.position - core.position;
        float bossAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = bossAngle + 180;
    }

    private void ShootFrag()
    {
        GameObject bullet = Instantiate(fragPrefab, fragFirePoint.position, fragFirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fragFirePoint.right * fragForce, ForceMode2D.Impulse);
    }

    private void ShootMissile()
    {
        GameObject bullet = Instantiate(missilePrefab, missileFirePoint.position, missileFirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(missileFirePoint.right * missileForce, ForceMode2D.Impulse);
    }


}
