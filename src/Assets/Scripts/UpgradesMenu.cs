using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesMenu : MonoBehaviour
{
    public static bool GameIsinUpgrades = false;

    public int healthUpgrade;

    public int fireRateUpgrade;

    public GameObject upgradesMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            if (GameIsinUpgrades)
            {
                ResumeGame();
            }
            else
            {
                ShowUpgrades();
            }
        }
    }
    public void ResumeGame()
    {
        upgradesMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsinUpgrades = false;
    }

    public void ShowUpgrades()
    {
        upgradesMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsinUpgrades = true;
    }

    public void HealthUpgrade()
    {
        healthUpgrade += 20;
    }

    public void FireRateUpgrade()
    {
        fireRateUpgrade += 20;
    }




}
