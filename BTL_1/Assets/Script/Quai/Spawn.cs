using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab c?a qu�i
    public Vector3 spawnPosition;  // V? tr� spawn c? ??nh
    public float spawnInterval = 30f; // Th?i gian gi?a m?i l?n spawn (gi�y)

    private float timer = 0f; // B? ??m th?i gian

    void Update()
    {
        // T?ng th?i gian tr�i qua
        timer += Time.deltaTime;

        // N?u ?� ?? 30 gi�y, spawn qu�i v� reset b? ??m
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
            Debug.Log("Qu�i ?� spawn ? v? tr�: " + spawnPosition);
        }
        else
        {
            Debug.LogWarning("Prefab qu�i ch?a ???c g�n!");
        }
    }
}
