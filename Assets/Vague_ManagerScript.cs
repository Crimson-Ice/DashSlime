using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague_ManagerScript : MonoBehaviour
{
    public int Numero_VAGUE = 1;
    public List<GameObject> point_spawn = new List<GameObject>();
    private List<GameObject> point_spawn_utiliser;
    public GameObject Orc_prefab;
    public GameObject Skeleton_prefab;
    private List<GameObject> Ennemie_List = new List<GameObject>();

    void Start()
    {
        Spawn_vague(Numero_VAGUE);
    }

    void Spawn_vague(int numero_de_vague)
    {
        point_spawn_utiliser = new List<GameObject>(point_spawn);
        point_spawn_utiliser.RemoveAt(Random.Range(0, point_spawn_utiliser.Count));
        point_spawn_utiliser.RemoveAt(Random.Range(0, point_spawn_utiliser.Count));
        foreach(GameObject point in point_spawn_utiliser)
        {
            //init ennemie a la position du point
            //ajout dans la liste d'ennemie vivant
        }
    }
    void Update()
    {
        //si pu d'ennmie viviant sur le terrain refaire spawn une vague et numero_vague ++ (Ennemie_List vide)
    }
}
