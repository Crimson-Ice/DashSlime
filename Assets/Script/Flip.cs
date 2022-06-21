using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public ViseurMovement viseurMovement;

    void Update()
    {
        if(viseurMovement.angle < 0f && viseurMovement.angle > -180f)
            this.GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
    }
}
