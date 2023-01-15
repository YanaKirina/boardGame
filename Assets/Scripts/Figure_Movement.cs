using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

[RequireComponent(typeof(Outline))]
public class Figure_Movement : MonoBehaviour
{
    private Dictionary<int, GameObject> NumToFigure = new Dictionary<int, GameObject>();
    
    private Dictionary<string, string> PlayerToFigure = new Dictionary<string, string>();
    
    private Outline outline;

    public GameObject Shooter, Lancer, Melee, Shooter1, Lancer1, Melee1;

    public GameObject ChosenFigure, ChosenTile, CurrentTile, hex_start, hex_end;

    public Transform Grid;
    
    [Header("Radius of finding available tiles   13 is recomended")]
    public int Radius = 13;
    
    [Header("Default and available for movement tile materials")]
    public Material NewMaterial, DefaultMaterial;

    [Header("Player turn")]
    public string whosTurn = "Player1Turn";
    void Start()
    {
        outline = GetComponent<Outline>();

        SetToStartPositions();

    }
    void SetToStartPositions()
    {
        NumToFigure.Add(1, Lancer);
        NumToFigure.Add(2, Melee);
        NumToFigure.Add(3, Shooter);
        NumToFigure.Add(4, Lancer1);
        NumToFigure.Add(5, Melee1);
        NumToFigure.Add(6, Shooter1);
        PlayerToFigure.Add("Player1Turn", "Player1Figure");
        PlayerToFigure.Add("Player2Turn", "Player2Figure");

        Instantiate(NumToFigure[DataHolder.hero1]);
        Instantiate(NumToFigure[DataHolder.hero2]);
        Instantiate(NumToFigure[DataHolder.hero3]);
        Instantiate(NumToFigure[DataHolder.hero4]);
        Instantiate(NumToFigure[DataHolder.hero5]);
        Instantiate(NumToFigure[DataHolder.hero1t2]);
        Instantiate(NumToFigure[DataHolder.hero2t2]);
        Instantiate(NumToFigure[DataHolder.hero3t2]);
        Instantiate(NumToFigure[DataHolder.hero4t2]);
        Instantiate(NumToFigure[DataHolder.hero5t2]);
        GameObject[] P1Figures = GameObject.FindGameObjectsWithTag("Player1Figure");
        GameObject[] P2Figures = GameObject.FindGameObjectsWithTag("Player2Figure");
        foreach(GameObject p in P1Figures)
        {
            p.transform.SetParent(Grid);
        }
        foreach(GameObject p in P2Figures)
        {
            p.transform.SetParent(Grid);
        }
        float[] x_spots = { 1.731953f, 0.8659766f, 0f, -0.8659766f, -1.731953f, -2.59793f };
        float[] z_spots = { -4.5f, 3 };
        for (int i = 0; i < P1Figures.Length; i++)
        {
            Vector3 pos = P1Figures[i].transform.position;
            pos.x = x_spots[i] * 4;
            pos.z = z_spots[0] * 4;
            Quaternion rot = P1Figures[i].transform.rotation;
            rot.y = 0f;
            P1Figures[i].transform.position = pos;
            P1Figures[i].transform.rotation = rot;
        }
        for (int i = 0; i < P2Figures.Length; i++)
        {
            Vector3 pos = P2Figures[i].transform.position;
            pos.x = x_spots[i] * 4;
            pos.z = z_spots[1] * 4;
            Quaternion rot = P2Figures[i].transform.rotation;
            rot.y = 180f;
            P2Figures[i].transform.position = pos;
            P2Figures[i].transform.rotation = rot;
        }
    }
    void OnButtonClick()
    {
        //p1turn = !p1turn;
    }

    public Collider[] RangeCheck()
    {
        if (ChosenFigure != null)
        {
            Collider[] hexs_around = Physics.OverlapSphere(ChosenFigure.transform.position, Radius, LayerMask.GetMask("Tilemap"));
            return (hexs_around);
        }
        else
        {
            return null;
        }
    }
    void Figure_Chose()
    {
        Vector3 position = ChosenFigure.transform.position;
        RaycastHit hit;
        Physics.Raycast(position, Vector3.down,out hit, 50);
        //CurrentTile = hit.transform.gameObject;
        //hex_start = CurrentTile;
        position.y += 3;
        outline.OutlineWidth = 3;
        ChosenFigure.transform.position = position;
        if (RangeCheck() != null)
        {
            foreach (Collider hex in RangeCheck())
            {
                hex.GetComponent<MeshRenderer>().material = NewMaterial;
                TileScript tileS = hex.gameObject.GetComponent<TileScript>();
                tileS.isAvailable = true;
            }
        }
    }
    void Figure_Move()
    {
        if (RangeCheck() != null)
        {
            foreach (Collider hex in RangeCheck())
            {
                hex.GetComponent<MeshRenderer>().material = DefaultMaterial;
                TileScript tileS = hex.gameObject.GetComponent<TileScript>();
                tileS.isAvailable = false;
            }
        }
        Vector3 figPos = ChosenFigure.transform.position;
        Vector3 tilePos = ChosenTile.transform.position;
        hex_end = ChosenTile;
        figPos.x = tilePos.x;
        figPos.z = tilePos.z;
        figPos.y -= 3;
        ChosenFigure.transform.position = figPos;
        TileScript tileScript = ChosenTile.GetComponent<TileScript>();
        //tileScript.isTaken = true; 
        //ChosenFigure.gameobject.SetActive(false);
        ChosenFigure = null;
        ChosenTile = null;
    }
    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(ray, out hitInfo, 200);
            if (hit)
            {
                if (hitInfo.transform.gameObject.CompareTag(PlayerToFigure[whosTurn]))
                {
                    if (ChosenFigure == null)
                    {
                        ChosenFigure = hitInfo.transform.gameObject;
                        Figure_Chose();
                    }
                }
                else if (hitInfo.transform.gameObject.CompareTag("TilemapTile"))
                {
                    if (ChosenTile == null)
                    {
                        ChosenTile = hitInfo.transform.gameObject;
                        TileScript tileS = ChosenTile.GetComponent<TileScript>();
                        if (ChosenFigure != null && tileS.isAvailable && !tileS.isHighGround)
                        {
                            Figure_Move();
                        }
                        else
                        {
                            Debug.LogWarning("Trying to move onto highground or taken tile");
                            ChosenTile = null;
                        }
                    }
                }
                else
                {
                    Debug.Log("Neither figure nor tile chosen");
                }
            }
            else
            {
                Debug.Log("Smth happend");
            }
        }
    }
    void PlayerTurn()
    {
        PlayerMove();
    }
    void Update()
    {
        PlayerTurn();
    }
}
