using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamge : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
