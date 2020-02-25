using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D body;
    
    SpriteRenderer m_SpriteRenderer;
    private Animator animator;
    private GameObject lifeBar;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private float variableJumpHeightMultiplier = 0.5f;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpForce = 16.0f;
    [SerializeField] private float movementForceInAir;
    
    [SerializeField] int speed;
    
    [SerializeField] float timeRegen;
    
    private float lastTimeDamage;

    private bool isGrounded;
    private bool canJump;
    private bool isFacingRight = true;
    
    private bool hasBeenCalled = false;
    private float direction;
    
    // Start is called before the first frame update
    void Awake()
    {
        lifeBar = GameObject.FindWithTag("LifeBar");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate() {

        CheckSurroundings();
        
        ApplyMovements();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        CheckIfCanJump();
        
        CheckMovementDirection();

        if (Mathf.Abs(body.velocity.x) >= 0.1f && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        animator.SetFloat("YVelocity", body.velocity.y);
            
        animator.SetBool("isGrounded", isGrounded);
        
    }

    private void CheckInput()
    {
        direction = Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y * variableJumpHeightMultiplier);
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && direction < 0)
        {
            Flip();
        }
        else if (!isFacingRight && direction > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Debug.Log("Flip");
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void CheckIfCanJump()
    {
        if (isGrounded && body.velocity.y < 0.1f)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }

    private void ApplyMovements()
    {
        if (isGrounded)
        {
            body.velocity = new Vector2(speed * direction, body.velocity.y);
        }
        else if (!isGrounded && direction != 0)
        {
            Vector2 forceToAdd = new Vector2(movementForceInAir * direction, 0);
            body.AddForce(forceToAdd);

            if (Mathf.Abs(body.velocity.x) > speed)
            {
                body.velocity = new Vector2(speed * direction, body.velocity.y);
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Black") && BlackOrWhiteDmg.blackDamage || other.CompareTag("White") &&BlackOrWhiteDmg.whiteDamage)
        {
            TakingDamage();
        }
        else if(other.CompareTag("White") && !BlackOrWhiteDmg.whiteDamage || other.CompareTag("Black") && !BlackOrWhiteDmg.blackDamage)
        {
            NotTakingDamage();
        }
    }

    void TakingDamage()
    {
        lastTimeDamage = Time.time +timeRegen;
        lifeBar.GetComponent<LifeBar>().LoseLife(0.01f);
    }

    void NotTakingDamage()
    {
        if (Time.time > lastTimeDamage)
        {
            lifeBar.GetComponent<LifeBar>().LoseLife(-0.01f);
        }
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    
}
