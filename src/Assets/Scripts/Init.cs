using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Init {
    public int initHealth;
    public int initMaxHealth;
    

    public Init (int health, int maxHealth)
    {
        initHealth = health;
        initMaxHealth = maxHealth;
    }
}
