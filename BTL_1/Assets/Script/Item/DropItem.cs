using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject itemPrefab;
    Animator animator;
    [SerializeField] BoxCollider2D chestCollider;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        chestCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        bool check = FindObjectOfType<GameController3>().ischeckMang();
        if (check == true && collision.tag == "Player")
        {
            if (itemPrefab != null)
            {
                
                animator.SetBool("moruong", true);
                Instantiate(itemPrefab, transform.position, Quaternion.identity);
                chestCollider.isTrigger = false;
            }
            
        }
        
    }
}
