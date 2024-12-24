using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab c?a qu�i
    public GameObject bossPrefab;        // Prefab c?a boss
    public Transform[] spawnPoints;      // C�c v? tr� spawn qu�i
    public Transform bossSpawnPoint;     // V? tr� spawn boss
    public float spawnInterval = 5f; // Th?i gian spawn qu�i (gi�y)
    public int totalEnemiesToDefeat = 10; // S? l??ng qu�i c?n ti�u di?t ?? xu?t hi?n boss
    private int enemiesDefeated = 0;     // S? qu�i ?� b? ti�u di?t
    private bool bossSpawned = false;    // C? ki?m tra boss ?� xu?t hi?n ch?a
    private float timer = 0f; // B? ??m th?i gian

    void Start()
    {
        // Spawn qu�i ??u ti�n
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    void Update()
    {
        if (!bossSpawned)
        {
            // T?ng th?i gian v� spawn qu�i n?u c?n
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }
    }

    // H�m spawn qu�i
    void SpawnEnemy()
    {
        if (enemiesDefeated < totalEnemiesToDefeat)
        {
            // Ch?n v? tr� spawn ng?u nhi�n
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }

    // H�m g?i khi qu�i b? ti�u di?t
    public void OnEnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= totalEnemiesToDefeat && !bossSpawned)
        {
            SpawnBoss();
        }
    }

    // H�m spawn boss
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
