using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

[RequireComponent(typeof(Outline))]
public class Figure_Movement : MonoBehaviour
{
    private Dictionary<int, GameObject> NumToFigure = new Dictionary<int, GameObject>();

    private Outline outline;

    public GameObject Shooter, Lancer, Melee, Shooter1, Lancer1, Melee1;

    public GameObject ChosenFigure, ChosenTile, CurrentTile, hex_start, hex_end;

    public Transform Grid;
    
    [Header("Radius of finding available tiles   13 is recomended")]
    public int Radius = 13;
    
    [Header("Default and available for movement tile materials")]
    public Material NewMaterial, DefaultMaterial;

    [Header("Player turn")]
    public bool Player1Turn;
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
        Player1Turn = true;

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
    void FigureAttack(GameObject GO1, GameObject GO2)
    {
        // int Power1 = GO1.GetComponent<FigureScript>().Power;
        // int Power2 = GO2.GetComponent<FigureScript>().Power;
        int Attacking = GO1.GetComponent<FigureScript>().Power;
        int Suffering = GO1.GetComponent<FigureScript>().Power;

        // int Attacking1 = 10; 
        int Throws = Attacking / 4;
        if (Attacking % 4 > 0){
            Throws++;
        }
        // Debug.Log(Throws);

        int[] Bone = new int[Throws];
        int Damage = 0;

        System.Random random = new System.Random();
        for (int i = 0; i < Throws; i++){
            Bone[i] = random.Next(1,12);

            if (Bone[i] > 6){
                Damage++;
            }
            Debug.Log(Bone[i]);
        }
        // Debug.Log(Damage);
        Suffering -= Damage;
        // Debug.Log(Suffering);



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
                GameObject HitGO = hitInfo.transform.gameObject;
                if (HitGO.CompareTag("Player1Figure") || HitGO.CompareTag("Player2Figure"))
                {
                    if ((ChosenFigure == null && HitGO.tag == "Player1Figure" && Player1Turn) || (ChosenFigure == null && HitGO.tag == "Player2Figure" && !Player1Turn))
                    {
                        ChosenFigure = HitGO;
                        Figure_Chose();
                    }
                    else if (ChosenFigure != null && HitGO.CompareTag(ChosenFigure.tag))
                    {
                        Debug.Log("Cannot move onto figure");
                    }
                    else if (ChosenFigure != null && !HitGO.CompareTag(ChosenFigure.tag))
                    {
                        FigureAttack(ChosenFigure, HitGO);
                    }
                    else
                    {
                        Debug.Log("It's not your turn!");
                    }
                }
                else if (HitGO.CompareTag("TilemapTile"))
                {
                    if (ChosenTile == null)
                    {
                        ChosenTile = HitGO;
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
