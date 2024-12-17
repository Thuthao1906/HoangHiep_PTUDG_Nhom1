using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rg;
    Vector2 moveInput;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 10f;
    [SerializeField] float climp = 5f;
    float mygravityScale;
    Animator animator;
    PolygonCollider2D playercollider;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playercollider = GetComponent<PolygonCollider2D>();
        mygravityScale = rg.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipPlayer();
        Climp();
    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * speed, rg.velocity.y);
        rg.velocity = playerVelocity;
        bool playerHorizontalSpeed = Mathf.Abs(rg.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHorizontalSpeed);
    }
    void FlipPlayer()
    {
        bool playerHorizontalSpeed = Mathf.Abs(rg.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rg.velocity.x), 1f);
        }
    }

    void Climp()
    {
        if (!playercollider.IsTouchingLayers(LayerMask.GetMask("Climping")))
        {
            animator.SetBool("isClimping", false);
            rg.gravityScale = mygravityScale;
            return;

        }
        Vector2 climpVelocity = new Vector2(rg.velocity.x, moveInput.y * climp);
        rg.velocity = climpVelocity;
        rg.gravityScale = 0;
        bool climpHorizontalSpeed = Mathf.Abs(rg.velocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimping", climpHorizontalSpeed);
    }
    void OnJump(InputValue value)
    {
        if (value.isPressed && (Mathf.Abs(rg.velocity.y) < 0.0001))
        {
            rg.velocity += new Vector2(rg.velocity.x, jump);
        }

    }
}
