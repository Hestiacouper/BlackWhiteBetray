using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOrWhiteDmg : MonoBehaviour
{
    public static bool blackDamage = true;
    public static bool whiteDamage = false;
    void Start()
    {
        InvokeRepeating("BlackOrWhiteDamage", 0.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlackOrWhiteDamage()
    {
        blackDamage = !blackDamage;
        whiteDamage = !whiteDamage;
        Debug.Log("BlackDamage:");
        Debug.Log(blackDamage);
        Debug.Log("WhiteDamage:");
        Debug.Log(whiteDamage);
    }
}
