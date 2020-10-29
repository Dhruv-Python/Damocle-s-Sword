using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    [SerializeField] bool isBoss;

    [SerializeField] GameObject smallExplosion;
    [SerializeField] GameObject bigExplosion;

    private void Start() {
        Init data = SaveSystem.LoadHealth();
        if (isBoss)
        {
            health = OpponentHPIncreaser.initBossHealth;
        } else
        {
            health = OpponentHPIncreaser.initEnemyHealth;
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        SceneScripts.killCount++;
        OpponentHPIncreaser.kills++;
        if (!isBoss)
        {
            GameObject Explosion = Instantiate(smallExplosion, transform.position, transform.rotation);
            AudioManager.PlaySound("EnemyDeath_Sound");
            Destroy(Explosion, 0.6f);
        } else 
        {
            GameObject Explosion = Instantiate(bigExplosion, transform.position, transform.rotation);
            AudioManager.PlaySound("BossDeath_Sound");
            GameObject.Find("Script Manager").GetComponent<BossSpawner>().WonBossFight();
            Destroy(Explosion, 1f);
        }
        
        Destroy(gameObject);
    }

}
