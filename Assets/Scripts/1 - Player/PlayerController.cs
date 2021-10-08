using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float PlayerSpeed;
    private float moveInput;
    public float JumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRad;
    public LayerMask whatIsGorund;

    private float JumpTimeTimer;
    public float JumpTime;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * PlayerSpeed, rb.velocity.y);
    }

   
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRad, whatIsGorund);

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            JumpTimeTimer = JumpTime;
            rb.velocity = Vector2.up * JumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(JumpTimeTimer > 0)
            {
                rb.velocity = Vector2.up * JumpForce;
                JumpTimeTimer -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
