using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] bool isEnemyBullet;
    bool debounce = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEnemyBullet && debounce)
        {
            debounce = false;
            Health health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(20);
            }
        }

        //Containerhealth core = HitInfo.gameObject.transform.parent.gameObject.GetComponent<Containerhealth>();
        Containerhealth core = collision.gameObject.GetComponent<Containerhealth>();
        if(core != null && debounce)
        {
            debounce = false;
            core.TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
