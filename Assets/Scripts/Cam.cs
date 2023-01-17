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
            FM.Player1Turn = !FM.Player1Turn;
        }
    }
}
