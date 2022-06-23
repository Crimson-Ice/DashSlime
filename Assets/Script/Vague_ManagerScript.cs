using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague_ManagerScript : MonoBehaviour
{
    public int Numero_VAGUE = 1;
    public List<Transform> point_spawn = new List<Transform>();
    private List<Transform> point_spawn_utiliser;
    public GameObject Orc_prefab;
    public GameObject Skeleton_prefab;
    private List<GameObject> Ennemie_List = new List<GameObject>();

    void Start()
    {
        Spawn_vague(Numero_VAGUE);
    }

    void Update()
    {
        //si pu d'ennmie viviant sur le terrain refaire spawn une vague et numero_vague ++ (Ennemie_List vide)
    }

    ///<summary>
    /// fait spawn une vague d'ennemie
    ///</summary>
    void Spawn_vague(int numero_de_vague)
    {
        point_spawn_utiliser = new List<Transform>(point_spawn);
        point_spawn_utiliser = RemovePoint(3, point_spawn_utiliser);
        
        foreach(Transform point in point_spawn_utiliser)
        {
            //init ennemie a la position du point
            GameObject ennemie = Instantiate(Orc_prefab, point.position, Quaternion.identity);
            //ajout dans la liste d'ennemie vivant
            Ennemie_List.Add(ennemie);
        }
    }

    ///<summary>
    /// Enlever un certains nombre d'object de la liste
    ///</summary>
    List<Transform> RemovePoint(int nb, List<Transform> list_point)
    {
        for (int i = 0; i < nb; i++)
        {
            list_point.RemoveAt(Random.Range(0, list_point.Count));   
        }

        return list_point;
    }


    
}
