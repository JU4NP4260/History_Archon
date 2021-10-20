using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement & Jumping")]
    public float PlayerSpeed;
    public float JumpForce;
    public float JumpTime;
    public Transform feetPos;
    public float checkRad;
    public LayerMask whatIsGorund;


    [Header("Health")]
    public float godModeTime = 1.5f;
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Miscelanious")]
    public Vector2 anglesToRotate;



    bool facingRight = true;
    bool godModeOn;

    private bool isGrounded;
    private float JumpTimeTimer;
    private float godModeOnTimer;
    private bool isJumping;
    private float moveInput;

    private Rigidbody2D rb;


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
        float horizontalInput = Input.GetAxis("Horizontal");


        if (godModeOn)
        {
            godModeOnTimer -= Time.deltaTime;
            if (godModeOnTimer < 0)
                godModeOn = false;

        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            godModeOn = true;
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
    }



    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }
    }
}
