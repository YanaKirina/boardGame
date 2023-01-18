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
    private Outline outline;

    public GameObject ChosenFigure, ChosenTile, CurrentTile, hex_start, hex_end;

    [Header("Radius of finding available tiles   13 is recomended")]
    public int Radius = 13;

    [Header("Default and available for movement tile materials")]
    public Material NewMaterial, DefaultMaterial;

    [Header("Player turn")]
    public bool Player1Turn;
    void Start()
    {
        outline = GetComponent<Outline>();
        Player1Turn = true;
    }
    public string Figure_Str(bool P1T)
    {
        if (P1T)
        {
            return "Player1Figure";
        }
        else
        {
            return "Player2Figure";
        }
    }
    public Collider[] Movement_RangeCheck()
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
    public Collider[] Attack_RangeCheck()
    {
        if (ChosenFigure != null)
        {
            string FClass = ChosenFigure.GetComponent<FigureScript>().Figure_Class;
            if (FClass == "Melle")
            {
                Collider[] Enemy_Figures = Physics.OverlapSphere(ChosenFigure.transform.position, Radius, LayerMask.GetMask(Figure_Str(Player1Turn)));

            }
        }
        return null;
    }
    void Figure_Chose()
    {
        if (ChosenFigure.GetComponent<FigureScript>().MovementAP == true)
        {
            Vector3 position = ChosenFigure.transform.position;
            RaycastHit hit;
            Physics.Raycast(position, Vector3.down, out hit, 50);
            //CurrentTile = hit.transform.gameObject;
            //hex_start = CurrentTile;
            position.y += 3;
            outline.OutlineWidth = 3;
            ChosenFigure.transform.position = position;
            if (Movement_RangeCheck() != null)
            {
                foreach (Collider hex in Movement_RangeCheck())
                {
                    hex.GetComponent<MeshRenderer>().material = NewMaterial;
                    TileScript tileS = hex.gameObject.GetComponent<TileScript>();
                    tileS.isAvailable = true;
                }
            }
        }
        else
        {
            Debug.Log("This charecter acted already");
            ChosenFigure = null;
            ChosenTile = null;
        }
    }
    void Figure_Move()
    {
        if (Movement_RangeCheck() != null)
        {
            foreach (Collider hex in Movement_RangeCheck())
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
        ChosenFigure.GetComponent<FigureScript>().MovementAP = false;
        ChosenFigure = null;
        ChosenTile = null;
    }
    void FigureAttack(GameObject GO1, GameObject GO2)
    {
        int Attacking = GO1.GetComponent<FigureScript>().Power;
        int Suffering = GO2.GetComponent<FigureScript>().Power;

        // int Attacking1 = 10; 
        int Throws = Attacking / 4;
        if (Attacking % 4 > 0)
        {
            Throws++;
        }
        //Debug.Log(Throws);

        int[] Bone = new int[Throws];
        int Damage = 0;

        System.Random random = new System.Random();
        for (int i = 0; i < Throws; i++)
        {
            Bone[i] = random.Next(1, 12);

            if (Bone[i] > 6)
            {
                Damage++;
            }
            //Debug.Log(Bone[i]);
        }
        Debug.Log(Damage);
        Suffering -= Damage;
        Debug.Log(Suffering);
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
                        Debug.Log("Attack, don't move");
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
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(ray, out hitInfo, 200);
            if (hit)
            {
                GameObject HitGO = hitInfo.transform.gameObject;
                if (HitGO.CompareTag("Player1Figure") || HitGO.CompareTag("Player2Figure"))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        hitInfo = new RaycastHit();
                        ChosenFigure = hitInfo.transform.gameObject;
                    }
                }
                else
                {
                    Debug.Log("Move, not attack 3");
                }
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