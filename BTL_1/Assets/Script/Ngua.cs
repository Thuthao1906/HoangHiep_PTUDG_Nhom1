using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ngua : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField]  private BoxCollider2D boxCollider;
    [SerializeField]  private LayerMask playerLayer;

    private float cooldownTimer=Mathf.Infinity;
    private Animator anima;

    private Health playerHealth;
    private EnemyPatrol enemyPatrol; 

    public void Awake()
    {
        anima = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInsight())
        {
            if(cooldownTimer > attackCooldown)
            {
                cooldownTimer = 0;
                anima.SetTrigger("attack");
            }
        }
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInsight();
        }
        
    }
    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range*transform.localScale.x* colliderDistance
            ,new Vector2(boxCollider.bounds.size.x*range,boxCollider.size.y),0,Vector2.left, 0,playerLayer);
        if(hit.collider !=null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider!=null; 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector2(boxCollider.bounds.size.x * range, boxCollider.size.y));
    }

    private void DamegePlayer()
    {
        if (PlayerInsight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
