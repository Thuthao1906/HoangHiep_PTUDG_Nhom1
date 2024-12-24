using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoDuoi : MonoBehaviour
{
    public Transform player; // Nhân vật
    public float speed = 2f; // Tốc độ di chuyển
    public float chaseRangeY = 2f;
    public float chaseRangeX = 5f; // Khoảng cách phát hiện nhân vật
    public float patrolDistance = 3f; // Khoảng cách tuần tra
    [SerializeField] float damage; //damage cua ho

    private Vector2 startingPosition; // Vị trí ban đầu
    private Rigidbody2D rb;
    private bool isChasing = false; // Trạng thái đuổi theo
    private bool movingRight = true; // Hướng tuần tra


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceX = Mathf.Abs(player.position.x - transform.position.x);
        float distanceY = Mathf.Abs(player.position.y - transform.position.y);


        if (distanceX <= chaseRangeX && distanceY <= chaseRangeY)
        {
            // Bắt đầu đuổi theo
            isChasing = true;
        }
        else
        {
            // Trở về trạng thái tuần tra
            isChasing = false;
        }
        
    }
    void FixedUpdate()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }
    
    private void ChasePlayer()
    {
        // Chỉ di chuyển theo trục X
        float direction = player.position.x > transform.position.x ? 1 : -1;
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void Patrol()
    {
        // Tuần tra theo trục X quanh vị trí ban đầu
        if (movingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > startingPosition.x + patrolDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < startingPosition.x - patrolDistance)
            {
                movingRight = true;
            }
        }
    }
    void UpdateFacingDirection()
    {
        // Quay mặt kẻ thù về hướng di chuyển
        Vector3 scale = transform.localScale;
        scale.x = rb.velocity.x > 0 ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void LateUpdate()
    {
        UpdateFacingDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Health>().TakeDamage(damage);
        }
    }
}
