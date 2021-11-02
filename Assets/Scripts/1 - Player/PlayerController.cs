using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

    bool m_FacingRight = true;
    bool godModeOn;

    private bool isGrounded;
    private float JumpTimeTimer;
    private float godModeOnTimer;
    private bool isJumping;
    private float moveInput;
    private int currentScene;

    private Rigidbody2D rb;
    public Animator animator;
    public GameObject HealthBar;
    public GameObject OverScreen;
    public GameObject Spear;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * PlayerSpeed, rb.velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (moveInput > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveInput < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

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

        if (currentHealth <= 0)
        {
            death();
        }
    }

    void death()
    {
       if(currentHealth <= 0)
       {
            StartCoroutine("Respawn");
       }
        
    }

    IEnumerator Respawn()
    {
        Gameover();
        yield return new WaitForSeconds(3.2f);
        OverScreen.SetActive(false);
        HealthBar.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Gameover()
    {
        OverScreen.SetActive(true);
        HealthBar.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            death();
        }
    }

    private void Flip()
    {

        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
