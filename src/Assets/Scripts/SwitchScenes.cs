using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    bool bossFightDelay = true;
    int bossHealth;
    int enemyHealth;

    Containerhealth containerHealth;

    private void Start() {
        containerHealth = GameObject.Find("Core_Container").GetComponent<Containerhealth>();
        bossHealth = OpponentHPIncreaser.initBossHealth;
        enemyHealth = OpponentHPIncreaser.initEnemyHealth;
    }

    public void GoToBoss()
    {
        SaveSystem.SaveData(containerHealth.health, containerHealth.maxHealth);
        if (!bossFightDelay) return;
        bossFightDelay = false;
        SceneManager.LoadScene("Bossfight");
    }

    public void WonBossFight()
    {
        OpponentHPIncreaser.initBossHealth += 25;
        OpponentHPIncreaser.initEnemyHealth += 2;
        SceneScripts.overallKillCount += SceneScripts.killCount;
        SceneScripts.killCount = 0; 
        SceneManager.LoadScene("SampleScene");
        containerHealth.WonBossFight();
        
    }

}
