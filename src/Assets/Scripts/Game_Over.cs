using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{

    public GameObject GameOver_Overlay;

    public void GameOver()
    {
        GameOver_Overlay.SetActive(true);

        StartCoroutine(Leaderboard());
    }

    IEnumerator Leaderboard()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene_HighscoreTable");
    }
}
