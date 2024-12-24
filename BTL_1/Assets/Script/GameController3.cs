using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    public GameObject enemyPrefab;       // prefab cua quai
    public GameObject bossPrefab;        // prefab cua boss
    public Transform[] spawnPoints;      // cac vi tri spawn quai
    public Transform bossSpawnPoint;     // vi tri spawn boss
    public float spawnInterval = 5f; // Thoi gian spawn quai
    public int totalEnemiesToDefeat = 10; // so luong quai can tieu diet de ruong xuat hien
    private int enemiesDefeated = 0;     // so quai da tieu diet
    private bool bossSpawned = false;    // Kiem tra boss duoc spawn ra chua
    private float timer = 0f; // B? ??m th?i gian
    public bool requiredItem=false; //Tinh trang vat pham da mo chua

    void Start()
    {
        // spawn turn quai dau
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    void Update()
    {
        if (!bossSpawned)
        {
            // Tang thoi gian va spawn quai
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
            // Chon vi tri spawn ngau nhien
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }

    // Ham khi quai bi tieu diet
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
    public void OnItemCollected()
    {
        //Kiem tra xem nhat duoc vat pham chua
        requiredItem= true;
    }
    public bool ischeckVatPham()
    {
        return requiredItem;
    }
}
