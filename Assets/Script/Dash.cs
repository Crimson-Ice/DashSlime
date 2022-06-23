using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 mousePos = new Vector2(0,0);
    private Vector3 Direction;
    public GameObject MaskViseur;
    public GameObject Viseur;

    public Hero_Stat hero_Stat;
    private bool CanDash = true;
    private float MovementCooldown;

    void Update()
    {

        //si on clique et que on peut dash
        if (Input.GetMouseButtonDown(0) && CanDash == true)
        {
            DashMovement();
            MaskViseur.transform.position = Viseur.transform.position;
            CanDash = false;
            MovementCooldown = 0.5f;
        }

        //si on ne peut pas dash
        if(CanDash == false)
        {   
            if(MovementCooldown <= 0f)
            {
                rb.velocity = new Vector2(0,0);
                CanDash = CanDashFonction();

                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                MovementCooldown -= Time.deltaTime;

                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Dit si le joueur peut dash ou non et bouge le mask du viseur
    /// </summary>
    private bool CanDashFonction()
    {
        //direction dans laquel le mask bouge
        Vector3 dirMask = MaskViseur.transform.position - transform.position;
        //fait bouger le mask (a une certaine vitesse)
        MaskViseur.transform.position += ((dirMask)/(2.5f/hero_Stat.Dash_speed)) * Time.deltaTime;
        //verifie la distance entre le mask du viseur et le joueur
        float dis = Vector3.Distance(MaskViseur.transform.position, transform.position);
        
        //si la distance est supérieur a 2.30 alors le joueur peut reDash et donc le viseur est en mode pret
        if(dis >= 2.55f)
            return true;
        else
            return false;
    }

    /// <summary>
    /// fait Dash le joueur
    /// </summary>
    private void DashMovement()
    {
        //position de la souris
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //calcule Direction = Destination - Source
        Direction = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)) - transform.position;
        //continue après la souris (le dash)
        Direction = Direction.normalized;
        //fait bouger le joueur

        rb.velocity = Direction * 15;
        //rb.MovePosition(transform.position + (Direction * 10));
    }
}
