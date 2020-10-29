using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInput : MonoBehaviour
{
    public TextMeshProUGUI playerKills;
    public TextMeshProUGUI playerNameInput;

    public string playerName;

    void Start()
    {
        playerKills.text = "Your Kills - " + OpponentHPIncreaser.kills.ToString();
    }

    public void GetPlayerName()
    {
        playerName = playerNameInput.text.ToUpper();
    }

    public string ReturnPlayerName()
    {
        return playerName;
    }
}
