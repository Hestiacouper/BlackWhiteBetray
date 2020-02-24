using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D body;
    Vector2 direction;
    SpriteRenderer m_SpriteRenderer;
    
    
    [SerializeField] int speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate() {
        
        body.velocity = direction;
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        
        
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
        m_SpriteRenderer.color = Color.red;
    }

    void NotTakingDamage()
    {
        m_SpriteRenderer.color = Color.green;
    }
    
    
}
