using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containerhealth : MonoBehaviour
{

    [SerializeField] GameObject scriptManager;

    [SerializeField] GameObject HealthBar;
    HealthBar healthBar;

    public int maxHealth;
    public int health;

    void Start()
    {
        healthBar = HealthBar.GetComponent<HealthBar>();
        
        Init data = SaveSystem.LoadHealth();

        maxHealth = data.initMaxHealth;
        health = data.initHealth;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        print(health);
        healthBar.SetHealth(health);
        if(health <= 0)
        {
            scriptManager.GetComponent<Game_Over>().GameOver();
        }
    }

    public void WonBossFight()
    {
        if (health <= maxHealth - (maxHealth/4)) 
        {
            health += maxHealth/4;
        } else
        {
            health = maxHealth;
        }
        SaveSystem.SaveData(health, maxHealth);

        healthBar.SetHealth(health);
    }
}
