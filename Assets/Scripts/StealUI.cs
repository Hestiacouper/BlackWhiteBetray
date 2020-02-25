using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StealUICall",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StealUICall()
    {
        float randomTime = Random.Range(10, 30);
 
        // Steal UI code
 
        Invoke("StealUICall", randomTime);
    }
}
