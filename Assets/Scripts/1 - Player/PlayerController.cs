using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float PlayerSpeed;
    private float moveInput;
    public float JumpForce;

    bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRad;
    public LayerMask whatIsGorund;

    private float JumpTimeTimer;
    public float JumpTime;
    private bool isJumping;

    public int maxHealth = 5;
    public int currentHealth;
    public float godModeTime = 1.5f;

    bool godModeOn;
    private float godModeOnTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * PlayerSpeed, rb.velocity.y);
    }

   
    void Update()
    {
        if (godModeOn)
        {
            godModeOnTimer -= Time.deltaTime;
            if (godModeOnTimer < 0)
                godModeOn = false;

        }


        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRad, whatIsGorund);

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

        if(Input.GetKeyDown(KeyCode.D))
        {
            facingRight = true;
            FlipRight();
        }
        else if(Input.GetKeyDown(KeyCode.A));
        {
            FlipLeft();
        }
    }

    void Flip()
    {
        if (facingRight == true)
        {
            transform.Rotate(0f, 0f, 0f);
        }
        else (facingRight != true)
        {

            transform.Rotate(0f, 180f, 0f);
        }
    }

    void FlipLeft()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(gameObject);

        }
    }
}
