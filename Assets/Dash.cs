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

    void Update()
    {

        //si on clique et que on peut dash
        if (Input.GetMouseButtonDown(0) && CanDash == true)
        {
            DashMovement();
            MaskViseur.transform.position = Viseur.transform.position;
            CanDash = false;
        }

        //si on ne peut pas dash
        if(CanDash == false)
        {   
            CanDash = CanDashFonction();
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
        MaskViseur.transform.position += (dirMask)/hero_Stat.Dash_speed * Time.deltaTime; //pensé a faire une fonction inverse avec la vitesse de dash
        //verifie la distance entre le mask du viseur et le joueur
        float dis = Vector3.Distance(MaskViseur.transform.position, transform.position);
        
        //si la distance est supérieur a 2.30 alors le joueur peut reDash et donc le viseur est en mode pret
        if(dis >= 2.15f)
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
        rb.MovePosition(transform.position + (Direction * 10));
    }
}
