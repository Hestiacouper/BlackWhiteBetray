using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealUI : MonoBehaviour
{
    SpriteRenderer m_spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetBlind",0);
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void GetBlind()
    {
        float randomTime = Random.Range(10, 30);
        Debug.Log("IM CHANGING COLOR");
        if (m_spriteRenderer.color == Color.white)
        {
            m_spriteRenderer.color = Color.black;
        }
        else if(m_spriteRenderer.color==Color.black)
        {
            m_spriteRenderer.color=Color.white;
        }
 
        Invoke("GetBlind", randomTime);
    }
}