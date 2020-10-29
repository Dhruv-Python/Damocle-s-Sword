using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPoint;

    [SerializeField] GameObject bossWarning;

    public static int killCount = 0;
    public static int overallKillCount = 0;

    public bool bossFightDelay = true;

    GameObject spawnLeftTop;
    GameObject spawnLeftBottom;

    GameObject spawnRightTop;
    GameObject spawnRightBottom;

    GameObject spawnTopRight;
    GameObject spawnTopLeft;

    GameObject spawnBottomLeft;
    GameObject spawnBottomRight;
    BossSpawner bossSpawner;

    [SerializeField] GameObject audioHandler;

    [SerializeField] GameObject switchScenes;

    private int spawnKillGoal = 0;

    private void Awake()
    {
        setSpawnLocations();
        Instantiate(audioHandler);
    }

    private void Update()
    {
        if (killCount == spawnKillGoal)
        {
            spawnKillGoal += 7;
            SpawnEnemies();
        }
        if (killCount >= 30)
        {
            switchScenes.GetComponent<SwitchScenes>().GoToBoss();
        } else if (killCount >= 25) 
        {
            bossWarning.SetActive(true);
        } else 
        {
            bossWarning.SetActive(false);
        }
    }

    public void GameOver()
    {
        print("ded");
    }

    private void SpawnEnemies() 
    { 
        GameObject Enemy1 = Instantiate(enemyPrefab, spawnRightTop.transform.position, spawnPoint.transform.rotation);
        GameObject Enemy2 = Instantiate(enemyPrefab, spawnRightBottom.transform.position, spawnPoint.transform.rotation);

        GameObject Enemy3 = Instantiate(enemyPrefab, spawnTopLeft.transform.position, spawnPoint.transform.rotation);
        GameObject Enemy4 = Instantiate(enemyPrefab, spawnTopRight.transform.position, spawnPoint.transform.rotation);
        
        GameObject Enemy5 = Instantiate(enemyPrefab, spawnBottomLeft.transform.position, spawnPoint.transform.rotation);
        GameObject Enemy6 = Instantiate(enemyPrefab, spawnBottomRight.transform.position, spawnPoint.transform.rotation);
        
        GameObject Enemy7 = Instantiate(enemyPrefab, spawnLeftTop.transform.position, spawnPoint.transform.rotation);
        GameObject Enemy8 = Instantiate(enemyPrefab, spawnLeftBottom.transform.position, spawnPoint.transform.rotation);
    }
            

    private void setSpawnLocations()
    {
        Vector3 leftTop = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, -0.5f, 10));
        Vector3 leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, -0.5f, 10));

        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 1.5f, 10));
        Vector3 rightBottom = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 1.5f, 10));

        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0.75f, 10));
        Vector3 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0.25f, 10));

        Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(-0.5f, 0.75f, 10));
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(-0.5f, 0.25f, 10));


        spawnLeftTop = Instantiate(spawnPoint, leftTop, Quaternion.identity);
        spawnLeftBottom = Instantiate(spawnPoint, leftBottom, Quaternion.identity);

        spawnRightTop = Instantiate(spawnPoint, rightTop, Quaternion.identity);
        spawnRightBottom = Instantiate(spawnPoint, rightBottom, Quaternion.identity);

        spawnTopRight = Instantiate(spawnPoint, topRight, Quaternion.identity);
        spawnTopLeft = Instantiate(spawnPoint, topLeft, Quaternion.identity);

        spawnBottomLeft = Instantiate(spawnPoint, bottomLeft, Quaternion.identity);
        spawnBottomRight = Instantiate(spawnPoint, bottomRight, Quaternion.identity);
    }
}
