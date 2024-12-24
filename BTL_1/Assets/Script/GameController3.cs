using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab c?a quái
    public GameObject bossPrefab;        // Prefab c?a boss
    public Transform[] spawnPoints;      // Các v? trí spawn quái
    public Transform bossSpawnPoint;     // V? trí spawn boss
    public float spawnInterval = 5f; // Th?i gian spawn quái (giây)
    public int totalEnemiesToDefeat = 10; // S? l??ng quái c?n tiêu di?t ?? xu?t hi?n boss
    private int enemiesDefeated = 0;     // S? quái ?ã b? tiêu di?t
    private bool bossSpawned = false;    // C? ki?m tra boss ?ã xu?t hi?n ch?a
    private float timer = 0f; // B? ??m th?i gian

    void Start()
    {
        // Spawn quái ??u tiên
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    void Update()
    {
        if (!bossSpawned)
        {
            // T?ng th?i gian và spawn quái n?u c?n
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
    }

    // Hàm spawn quái
    void SpawnEnemy()
    {
        if (enemiesDefeated < totalEnemiesToDefeat)
        {
            // Ch?n v? trí spawn ng?u nhiên
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }

    // Hàm g?i khi quái b? tiêu di?t
    public void OnEnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= totalEnemiesToDefeat && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    // Hàm spawn boss
    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        bossSpawned = true;
        Debug.Log("Ruong da xuat hien");
    }
    public bool ischeckMang()
    {
        if(enemiesDefeated >= totalEnemiesToDefeat)
        {
            return true;
        }
        return false;
    }
}
