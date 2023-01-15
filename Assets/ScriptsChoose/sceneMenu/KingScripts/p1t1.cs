using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1t1 : MonoBehaviour
{
    public bool king;
    public GameObject cam;
    public GameObject cam2;



    public void OnMouseDown()
    {
        king = true;
        Invoke("switchCam", 0.5f);
        DataHolder.kingP1T1 = true;
        DataHolder.kingP2T1 = false;
        DataHolder.kingP3T1 = false;
        DataHolder.kingP4T1 = false;
        DataHolder.kingP5T1 = false;

    }
    private void Update()
    {
        if (this.king == true)
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
