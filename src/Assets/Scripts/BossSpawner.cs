using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] Transform bossSpawnPoint;
    [SerializeField] Transform introText;
    [SerializeField] GameObject outroText;

    private bool waitTimeOver = false;
    public bool gameStarted = false;
    private bool debounce = true;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float enemySpawnTime = 2f;

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

    void Start()
    {
        SpawnBoss();
        StartCoroutine(wait());
        setSpawnLocations();
        Instantiate(audioHandler);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        waitTimeOver = true;
    }

    void Update()
    {
        if (!waitTimeOver) return;
        if (introText.position.y >= 1500f) 
        {
            //SpawnBoss();
        }
        introText.position += new Vector3(0f, Time.deltaTime * 750);
    }

    private void SpawnBoss()
    {
        if (!debounce) return;
        debounce = false;
        bossSpawnPoint.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.5f, 10));
        Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
        StartCoroutine(SpawnEnemies());
    }

    public void GameOver()
    {
        print("ded");
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnTime);

            GameObject spawnLocation = enemySpawnPosition();
            GameObject Enemy = Instantiate(enemyPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
        }
        
    }

     private GameObject enemySpawnPosition()
     {
        int randomInt = Random.Range(1, 8);

        if (randomInt == 1) {
            return spawnLeftTop;
        }
        else if (randomInt == 2) {
            return spawnLeftBottom;
        }
        else if (randomInt == 3) {
            return spawnBottomLeft;
        }
        else if (randomInt == 4) {
            return spawnBottomRight;
        }
        else if (randomInt == 5) {
            return spawnRightBottom;
        }
        else if (randomInt == 6) {
            return spawnRightTop;
        }
        else if (randomInt == 7) {
            return spawnTopRight;
        }
        else if (randomInt == 8) {
            return spawnTopLeft;
        }
        
        return spawnBottomLeft;
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

    public void WonBossFight()
    {
        StartCoroutine(ShowWonBossFight());
    }

    IEnumerator ShowWonBossFight()
    {
        yield return new WaitForSeconds(1.6f);
        outroText.SetActive(true);
        yield return new WaitForSeconds(1);
        GetComponent<SwitchScenes>().WonBossFight();
    }
}
