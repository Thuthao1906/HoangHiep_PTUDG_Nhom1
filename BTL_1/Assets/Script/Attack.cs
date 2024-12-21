using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private int damage;
    Player player;
    [SerializeField] private float attackCooldown;
    Animator animator;
    [SerializeField] bool isAlive = true;
    private float cooldownTime=Mathf.Infinity;
    private PolygonCollider2D pCollider;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();
        pCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAttack(InputValue value)
    {
        
        if (!isAlive) { return; }
        
        if (value.isPressed && cooldownTime > attackCooldown  )
        {
            attack();
            cooldownTime = Time.deltaTime;
        }
    }
    void attack()
    {

        animator.SetTrigger("isAttack");
        cooldownTime = 0;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
