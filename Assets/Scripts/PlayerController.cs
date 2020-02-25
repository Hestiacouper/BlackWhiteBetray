using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D body;
    Vector2 direction;
    SpriteRenderer m_SpriteRenderer;
    private Animator animator;
    private GameObject lifeBar;
    
    
    [SerializeField] int speed;
    
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
        
        body.velocity = direction;
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Mathf.Abs(body.velocity.x) >= 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
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
        lifeBar.GetComponent<LifeBar>().LoseLife(0.5f);
    }

    void NotTakingDamage()
    {
        m_SpriteRenderer.color = Color.green;
    }
    
    
}
