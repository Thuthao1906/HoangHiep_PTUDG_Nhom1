using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canine : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anima;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anima.SetBool("run", false);
    }
    private void Update()
    {

        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDrection(-1);
            else
            {
                DirectionChage();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDrection(1);
            else
            {
                DirectionChage();
            }
        }
    }

    private void DirectionChage()
    {
        anima.SetBool("run", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }

    }

    private void MoveInDrection(int derection)
    {
        idleTimer = 0;
        anima.SetBool("run", true);
        enemy.localScale = new Vector3(-initScale.x * derection, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * derection * speed, enemy.position.y, enemy.position.z);
    }
}
