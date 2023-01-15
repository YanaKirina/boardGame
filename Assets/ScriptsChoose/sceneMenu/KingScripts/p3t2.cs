using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class p3t2 : MonoBehaviour
{
    public bool king2;

    public void OnMouseDown()
    {
        king2 = true;
        DataHolder.kingP1T2 = false;
        DataHolder.kingP2T2 = false;
        DataHolder.kingP3T2 = true;
        DataHolder.kingP4T2 = false;
        DataHolder.kingP5T2 = false;
        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        if (this.king2 == true)
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
}
