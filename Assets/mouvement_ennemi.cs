using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement_ennemi : MonoBehaviour
{
    public Transform Square;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 mouvement;

    ///<summary>
    /// Suit le joueur en fonction de sa position
    ///</summary>
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();  // Initialise le rigideBody

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Square.position - transform.position;
        // Calcul l'angle de rotation par rapport au joueur
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        //Fait la rotation de l'ennemi en fonction de la position du joueur
        rb.rotation = angle;
        direction.Normalize(); //recupère les directions 
        mouvement = direction;
        
    }

    private void FixedUpdate() 
    {
        moveCaracter(mouvement);    
    }

    void moveCaracter(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
