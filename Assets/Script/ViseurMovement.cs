using UnityEngine;

public class ViseurMovement : MonoBehaviour
{
    public GameObject ancre;
    public float angle;
    // Update is called once per frame
    void Update()
    {
        //calcule Direction = Destination = Source
        Vector3 Direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) - ancre.transform.position;
        //calcule l'angle en utilisant la methode de tangent inverse
        angle = (Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg) - 90f;
        //change l'angle du gameeobject
        ancre.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
