using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  
    public Rigidbody2D rg;
    Vector2 moveInput;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 10f;
    [SerializeField] float climp = 5f;
    [SerializeField] private LayerMask groundPlayer;
    [SerializeField] private AudioClip chay;
    public GameObject hoiSinh;
         
    bool setGronded = false;
    float mygravityScale;
    [SerializeField] bool isAlive = true;
    Animator animator;
    CapsuleCollider2D playercollider;
    BoxCollider2D boxcolliderl;

    // Start is called before the first frame update
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playercollider = GetComponent<CapsuleCollider2D>();
        mygravityScale = rg.gravityScale;
        boxcolliderl = GetComponent<BoxCollider2D>();
        //mauHienTai = mauBanDau;
        //thanhmau.CapNhatThanhMau(mauHienTai, mauBanDau);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive) { return; }
        Run();
        FlipPlayer();
        Climp();
        //Death();
    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        if (!isAlive) { return; }
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, rg.linearVelocity.y);
        rg.linearVelocity = playerVelocity;
        
        
        bool playerHorizontalSpeed = Mathf.Abs(rg.linearVelocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHorizontalSpeed);
        
    }
    void FlipPlayer()
    {
        if (!isAlive) { return; }
        bool playerHorizontalSpeed = Mathf.Abs(rg.linearVelocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rg.linearVelocity.x), 1f);
        }
    }

    void Climp()
    {
        if (!isAlive) { return; }
        if (!playercollider.IsTouchingLayers(LayerMask.GetMask("Climping")))
        {
            animator.SetBool("isClimping", false);
            rg.gravityScale = mygravityScale;
            return;

        }
        Vector2 climpVelocity = new Vector2(rg.linearVelocity.x, moveInput.y * climp);
        rg.linearVelocity = climpVelocity;
        rg.gravityScale = 0;
        bool climpHorizontalSpeed = Mathf.Abs(rg.linearVelocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimping", climpHorizontalSpeed);
    }
    void OnJump(InputValue value)
    {

        if (!isAlive) { return; }
        if (value.isPressed && Mathf.Abs(rg.linearVelocity.y)<0.001) { 
            rg.linearVelocity += new Vector2(rg.linearVelocity.x, jump);
            setGronded = false;
            animator.SetBool("isJumpping", !setGronded);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        setGronded = true;
        animator.SetBool("isJumpping", !setGronded);
    }
    private bool IsGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcolliderl.bounds.center, boxcolliderl.bounds.size, 0, Vector2.down, 0.1f, groundPlayer);
        return raycastHit.collider != null;
    }
    public void Death()
    {
       // elapseTime += Time.deltaTime;
      //  if (boxcolliderl.IsTouchingLayers(LayerMask.GetMask("Gai")))
       // {
       //     if (elapseTime > reloadTime)
       //     {
       //         mauHienTai -= 1;
        //        thanhmau.CapNhatThanhMau(mauHienTai, mauBanDau);
        //        elapseTime = 0;
        //    }
            
       // }
        //if (mauHienTai < 0)
        //{
            isAlive = false;
             animator.SetTrigger("Death");
             hoiSinh.SetActive(true);
             Vector2 death = new Vector2(rg.linearVelocity.x, 6f);
             rg.linearVelocity = death;
        //}
        
    }
    //public void Heal(float amount)
    //{
    //        mauHienTai = mauHienTai + amount;
    //        if (mauHienTai > mauBanDau)
    //            mauHienTai = mauBanDau;
    //        thanhmau.CapNhatThanhMau(mauHienTai, mauBanDau);
    //}
    
    public bool canAttack()
    {
        return IsGround();
    }
}
