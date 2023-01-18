using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Figure_Movement : MonoBehaviour
{
    private Outline outline;

    private Figure_Init FI; 

    public GameObject ChosenFigure, ChosenTile, CurrentTile, hex_start, hex_end;

    [Header("Radius of finding available tiles   13 is recomended")]
    public int Radius = 13;

    [Header("Default and available for movement tile materials")]
    public Material NewMaterial, DefaultMaterial, AttackMaterial;

    [Header("Player turn")]
    public bool Player1Turn;
    void Start()
    {
        outline = GetComponent<Outline>();
        Player1Turn = true;
    }
    private void hexs_clear()
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
    private Collider[] AttackRangeHighlight()
    {
        string FClass = ChosenFigure.GetComponent<FigureScript>().Figure_Class;
        Collider[] hexesR10 = Physics.OverlapSphere(ChosenFigure.transform.position, 10, LayerMask.GetMask("Tilemap"));
        Collider[] hexesR7 = Physics.OverlapSphere(ChosenFigure.transform.position, 7, LayerMask.GetMask("Tilemap"));
        Collider[] hexesR4 = Physics.OverlapSphere(ChosenFigure.transform.position, 4, LayerMask.GetMask("Tilemap"));
        if (FClass == "Melee" && hexesR4 != null)
        {
            Debug.Log("list returned");
            return hexesR4;
        }
        else if (FClass == "Lancer" && hexesR7 != null)
        {
            List<Collider> ListHexesR7 = hexesR7.ToList();
            foreach (Collider F in hexesR7.ToList())
            {
                if (hexesR4.Contains(F))
                {
                    ListHexesR7.Remove(F);
                }
            }
            Debug.Log("list returned");
            return ListHexesR7.ToArray();
        }
        else if (FClass == "Shooter" && hexesR10 != null)
        {
            List<Collider> ListHexesR10 = hexesR10.ToList();
            foreach (Collider F in hexesR10.ToList())
            {
                if (hexesR4.ToList().Contains(F) || hexesR7.ToList().Contains(F))
                {
                    ListHexesR10.Remove(F);
                }
            }
            Debug.Log("list returned");
            return ListHexesR10.ToArray();
        }
        return null;
    }
    public List<Collider> Attack_RangeCheck()
    {
        // 10 7 4
        if (ChosenFigure != null)
        {
            string FClass = ChosenFigure.GetComponent<FigureScript>().Figure_Class; 
            Collider[] Enemy_FiguresR10 = Physics.OverlapSphere(ChosenFigure.transform.position, 10, LayerMask.GetMask(Figure_Str(!Player1Turn)));
            Collider[] Enemy_FiguresR7 = Physics.OverlapSphere(ChosenFigure.transform.position, 7, LayerMask.GetMask(Figure_Str(!Player1Turn)));
            Collider[] Enemy_FiguresR4 = Physics.OverlapSphere(ChosenFigure.transform.position, 4, LayerMask.GetMask(Figure_Str(!Player1Turn)));
            if (FClass == "Melee" && Enemy_FiguresR4 != null)
            {
                Debug.Log("list returned");
                return Enemy_FiguresR4.ToList();
            }
            else if (FClass == "Lancer" && Enemy_FiguresR7 != null)
            {
                List<Collider> ListEnemy_FiguresR7 = Enemy_FiguresR7.ToList();
                foreach (Collider F in Enemy_FiguresR7.ToList())
                {
                    if (Enemy_FiguresR4.Contains(F))
                    {
                        ListEnemy_FiguresR7.Remove(F);
                    }
                }
                Debug.Log("list returned");
                return ListEnemy_FiguresR7;
            }
            else if (FClass == "Shooter" && Enemy_FiguresR10 != null)
            {
                List<Collider> ListEnemy_FiguresR10 = Enemy_FiguresR10.ToList();
                foreach (Collider F in Enemy_FiguresR10.ToList())
                {
                    if (Enemy_FiguresR4.ToList().Contains(F) || Enemy_FiguresR7.ToList().Contains(F))
                    {
                        ListEnemy_FiguresR10.Remove(F);
                    }
                }
                Debug.Log("list returned");
                return ListEnemy_FiguresR10;
            }
        }
        else 
        {
            Debug.Log("Ti eblan");
        }
        return null;
    }
    void Figure_Chose()
    {
        if (ChosenFigure.GetComponent<FigureScript>().MovementAP == true || ChosenFigure.GetComponent<FigureScript>().AttackAP == true)
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
                foreach (Collider ahex in AttackRangeHighlight())
                {
                    ahex.GetComponent<MeshRenderer>().material = AttackMaterial;
                }
            }
        }
        else
        {
            hexs_clear();
            Debug.Log("This charecter acted already");
            ChosenFigure = null;
            ChosenTile = null;
        }
    }
    void Figure_Move()
    {
        hexs_clear();
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
        if (Attack_RangeCheck().Contains(GO2.GetComponent<MeshCollider>()))
        {
            int Attacking = GO1.GetComponent<FigureScript>().Power;
            int Throws = Attacking / 4;
            if (Attacking % 4 > 0)
            {
                Throws++;
            }
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
            }
            Vector3 figPos = ChosenFigure.transform.position;
            figPos.y = 0.0325f;
            ChosenFigure.transform.position = figPos;
            foreach (Collider hex in Movement_RangeCheck())
            {
                hex.GetComponent<MeshRenderer>().material = DefaultMaterial;
                TileScript tileS = hex.gameObject.GetComponent<TileScript>();
                tileS.isAvailable = false;
            }
            Debug.Log(Damage);
            GO2.GetComponent<FigureScript>().Power -= Damage;
            Debug.Log(GO2.GetComponent<FigureScript>().Power);
            GO1.GetComponent<FigureScript>().AttackAP = false;
            hexs_clear();
            ChosenFigure = null;
        }
        else
        {
            hexs_clear();
            Vector3 figPos = ChosenFigure.transform.position;
            figPos.y = 0.0325f;
            ChosenFigure.transform.position = figPos;
            ChosenFigure = null;
            ChosenTile = null;
            Debug.Log("Figure out of range");
        }
        FI = GetComponent<Figure_Init>();
        foreach (GameObject F in FI.P1Figures)
        {
            if (F.GetComponent<FigureScript>().Power <= 0)
            {
                Destroy(F);
            }
            if (F.GetComponent<FigureScript>().IsKing)
            {
                if (F.GetComponent<FigureScript>().Power <= 0)
                {
                    Debug.LogWarning("Player 2 victory!");
                    break;
                }
            }
        }
        foreach (GameObject F in FI.P2Figures)
        {
            if (F.GetComponent<FigureScript>().Power <= 0)
            {
                Destroy(F);
            }
            if (F.GetComponent<FigureScript>().IsKing)
            {
                if (F.GetComponent<FigureScript>().Power <= 0)
                {
                    Debug.LogWarning("Player 1 victory!");
                    break;
                }
            }
        }
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
                    if ((ChosenFigure == null && HitGO.tag == "Player1Figure" && Player1Turn && HitGO.GetComponent<FigureScript>().MovementAP) || (ChosenFigure == null && HitGO.tag == "Player2Figure" && !Player1Turn && HitGO.GetComponent<FigureScript>().MovementAP))
                    {
                        ChosenFigure = HitGO;
                        Figure_Chose();
                    }
                    else if (ChosenFigure != null && !HitGO.CompareTag(ChosenFigure.tag) && ChosenFigure.GetComponent<FigureScript>().AttackAP)
                    {
                        FigureAttack(ChosenFigure, HitGO);
                    }
                    else if (ChosenFigure != null && HitGO.CompareTag(ChosenFigure.tag))
                    {
                        Debug.Log("Cannot move onto figure");
                    }
                    else if (ChosenFigure != null && !HitGO.CompareTag(ChosenFigure.tag) && !ChosenFigure.GetComponent<FigureScript>().AttackAP)
                    {
                        Debug.Log("Charecter already attacked");
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