using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab của quái
    public GameObject bossPrefab;        // Prefab của boss
    public Transform[] spawnPoints;      // Các vị trí spawn quái
    public Transform bossSpawnPoint;     // Vị trí spawn boss
    public float spawnInterval = 5f; // Thời gian spawn quái (giây)
    public int totalEnemiesToDefeat = 10; // Số lượng quái cần tiêu diệt để xuất hiện boss

    private int enemiesDefeated = 0;     // Số quái đã bị tiêu diệt
    private bool bossSpawned = false;    // Cờ kiểm tra boss đã xuất hiện chưa
    private float timer = 0f; // Bộ đếm thời gian
    [SerializeField] GameObject text;

    void Start()
    {
        // Spawn quái đầu tiên
        SpawnEnemy();
        SpawnEnemy();
        SpawnEnemy();
    }

    void Update()
    {
        if (!bossSpawned)
        {
            // Tăng thời gian và spawn quái nếu cần
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
            // Chọn vị trí spawn ngẫu nhiên
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }

    // Hàm gọi khi quái bị tiêu diệt
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
        Debug.Log("Boss đã xuất hiện!");
    }
    public void OnBossDefeated()
    {
        Debug.Log("Boss đã bị tiêu diệt!");
        // Chuyển qua màn mới (ví dụ: Scene tiếp theo)
      text.SetActive(true);
    }
}
