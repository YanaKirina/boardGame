using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class KingChange : MonoBehaviour
{

    public bool king;
    public GameObject cam;
    public GameObject cam2;

    

    public void OnMouseDown()
    {        
        king = true;
        Invoke("switchCam", 0.5f);
        print("lox");
    }
    private void Update()
    {
        if(this.king == true)
        {
            this.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
    }

    private void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void switchCam()
    {
        Instantiate(cam2);
        cam.gameObject.SetActive(false);       
        
    }

}
