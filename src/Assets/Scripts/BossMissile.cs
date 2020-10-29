using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{
    private bool debounce = true;

    private GameObject collidedWith;
    private float damage = 100f;
    private GameObject coreContainer;

    public GameObject sprite;
    public GameObject explosion;

    void Start()
    {
        coreContainer = GameObject.Find("Core_Container");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (!debounce) return;
            debounce = false;
            collidedWith = other.gameObject;
            collidedWith.GetComponent<Containerhealth>().TakeDamage(100);
            Explode(true);
        }

        if (other.gameObject.tag == "PlayerBullet")
        {
            if (!debounce) return;
            debounce = false;
            collidedWith = other.gameObject;
            Explode(false);
        }
    }

    private void Explode(bool collidedWithCore)
    {
        float finalDamage;
        sprite.SetActive(false);
        explosion.SetActive(true);
        StartCoroutine(DestroyObject());
        if (!collidedWithCore)
        {
            float distance = Vector2.Distance(transform.position, coreContainer.transform.position);
            print(distance + " = distance");
            if (distance >= 2.05f) { finalDamage = 0; }
            else {finalDamage = damage * (1/(distance*2f));}
        } else
        {
            finalDamage = 0;
        }

        Containerhealth containerHealth = coreContainer.GetComponent<Containerhealth>();
        if (containerHealth == null) return;
        int damageInt = Mathf.RoundToInt(finalDamage);
        containerHealth.TakeDamage(damageInt);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
