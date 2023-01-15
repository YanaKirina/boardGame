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
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
            FM = GetComponent<Figure_Movement>();
            if (FM.whosTurn == "Player1Turn")
            {
                FM.whosTurn = "Player2Turn";
            }
            else
            {
                FM.whosTurn = "Player1Turn";
            }
        }
    }
}
