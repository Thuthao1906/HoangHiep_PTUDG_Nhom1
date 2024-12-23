using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab c?a quái
    public Vector3 spawnPosition;  // V? trí spawn c? ??nh
    public float spawnInterval = 30f; // Th?i gian gi?a m?i l?n spawn (giây)

    private float timer = 0f; // B? ??m th?i gian

    void Update()
    {
        // T?ng th?i gian trôi qua
        timer += Time.deltaTime;

        // N?u ?ã ?? 30 giây, spawn quái và reset b? ??m
        if (timer >= spawnInterval)
        {
            SpawnEnemyAtFixedPosition();
            timer = 0f;
        }
    }

    void SpawnEnemyAtFixedPosition()
    {
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Quái ?ã spawn ? v? trí: " + spawnPosition);
        }
        else
        {
            Debug.LogWarning("Prefab quái ch?a ???c gán!");
        }
    }
}
