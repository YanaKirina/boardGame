using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure_Init : MonoBehaviour
{
    private Dictionary<int, GameObject> NumToFigure = new Dictionary<int, GameObject>();

    public GameObject[] P1Figures, P2Figures;

    public Transform Grid;

    public GameObject Shooter, Lancer, Melee, Shooter1, Lancer1, Melee1;
    public void SetToStartPositions()
    {
        P1Figures = GameObject.FindGameObjectsWithTag("Player1Figure");
        P2Figures = GameObject.FindGameObjectsWithTag("Player2Figure");
        foreach (GameObject p in P1Figures)
        {
            p.transform.SetParent(Grid);
        }
        foreach (GameObject p in P2Figures)
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
    void Start()
    {
        NumToFigure.Add(1, Lancer);
        NumToFigure.Add(2, Melee);
        NumToFigure.Add(3, Shooter);
        NumToFigure.Add(4, Lancer1);
        NumToFigure.Add(5, Melee1);
        NumToFigure.Add(6, Shooter1);

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

        SetToStartPositions();
    }

    // Update is called once per frame
    void Update()
    {
        P1Figures = GameObject.FindGameObjectsWithTag("Player1Figure");
        P2Figures = GameObject.FindGameObjectsWithTag("Player2Figure");
    }
}
