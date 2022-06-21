using UnityEngine;

///<summary>
/// Suit le joueur en fonction de sa position
///</summary>
public class mouvement_ennemi : MonoBehaviour
{
    public Transform Hero;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector3 mouvement;

    void Start()
    {
        Hero = GameObject.Find("Hero").transform;
        rb = this.GetComponent<Rigidbody2D>();  // Initialise le rigideBody

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Hero.position - transform.position;
        direction.Normalize(); //recupére les directions 
        mouvement = direction;
    }

    private void FixedUpdate() 
    {
        moveCaracter(mouvement);    
    }

    ///<summary>
    /// fait bouger l'ennemie
    ///</summary>
    void moveCaracter(Vector3 direction) 
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}

