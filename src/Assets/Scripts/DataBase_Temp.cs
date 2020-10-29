using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataBase_Temp : MonoBehaviour
{
    private int health;
    private int maxHealth;

    public void initVariables()
    {
        Health = 200;
        MaxHealth = 200;
    }

    public int Health {
        get {
            return health;
        }
        set {
            health = value;
        }
    }

        public int MaxHealth {
        get {
            return maxHealth;
        }
        set {
            maxHealth = value;
        }
    }
}
