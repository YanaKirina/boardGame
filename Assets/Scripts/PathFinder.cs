using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Queue<GameObject> hexs_queue = new Queue<GameObject>();
    public HashSet<GameObject> hexs_visited = new HashSet<GameObject>();
    private GameObject hex_start, hex_end;
    GameObject[] BFS(GameObject hex_start, GameObject hex_end)
    {
        if (GetComponent<Figure_Movement>().RangeCheck() != null)
        {
            hexs_queue.Enqueue(hex_start);
            hexs_visited.Add(hex_start);
            foreach (GameObject neighbor in getNeighbors(hex_start))
            {
                if (!hexs_visited.Contains(neighbor))
                {
                    hexs_queue.Enqueue(neighbor);
                    hexs_visited.Add(neighbor);
                }
            }
            foreach (Collider hex in GetComponent<Figure_Movement>().RangeCheck())
            {
                hexs_queue.Enqueue(hex.GetComponent<GameObject>());
            }
        }
        else
        {
            return null;
        }
        return null;
    }
    GameObject[] getNeighbors(GameObject curr)
    {
        Collider[] neighbours = Physics.OverlapSphere(curr.transform.position, 5, LayerMask.GetMask("Tilemap"));
        GameObject[] neighbours_go = new GameObject[neighbours.Length];
        foreach (Collider unit in neighbours)
        {
            neighbours_go.Append(unit.gameObject);
        }
        return neighbours_go;
    }
    // Start is called before the first frame update
    void Start()
    {
        hex_start = GetComponent<Figure_Movement>().hex_start;
        hex_end = GetComponent<Figure_Movement>().hex_end;
        BFS(hex_start, hex_end);
        //gameObject Figure = Figure_Movement.GetComponent<ChosenFigure>();
        Collider[] hexs_around = Physics.OverlapSphere(Vector3.zero, 10, LayerMask.GetMask("Tilemap"));
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
