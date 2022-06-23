using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnnemie : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("toucher");
        if(other.gameObject.name == "Hero")
            Destroy(gameObject);    
    }
}
