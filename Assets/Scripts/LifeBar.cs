using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    public void LoseLife(float damage)
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x-damage, transform.localScale.y, transform.localScale.z);
        }
    }
}