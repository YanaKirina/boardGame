using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public bool whichCamera = false;
    private Figure_Movement FM;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            FM = GetComponent<Figure_Movement>();
            if (FM.Player1Turn)
            {
                foreach (GameObject F in GameObject.FindGameObjectsWithTag("Player1Figure"))
                {
                    F.GetComponent<FigureScript>().MovementAP = true;
                    F.GetComponent<FigureScript>().AttackAP = true;
                }
            }
            else if (!FM.Player1Turn)
            {
                foreach (GameObject F in GameObject.FindGameObjectsWithTag("Player2Figure"))
                {
                    F.GetComponent<FigureScript>().MovementAP = true;
                    F.GetComponent<FigureScript>().AttackAP = true;
                }
            }
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
            FM.Player1Turn = !FM.Player1Turn;
        }
    }
}
