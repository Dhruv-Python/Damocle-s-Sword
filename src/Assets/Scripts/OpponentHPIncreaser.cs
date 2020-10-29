using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OpponentHPIncreaser
{
    public static int initBossHealth = 400;
    public static int initEnemyHealth = 11;

    public static int kills = 0;

    public static void SetOriginal()
    {
        initBossHealth = 400;
        initEnemyHealth = 11;
        kills = 0;
    }
}
