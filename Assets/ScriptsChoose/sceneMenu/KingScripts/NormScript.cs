using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormScript : MonoBehaviour
{
    public bool king;
    public GameObject cam;
    public GameObject cam2;
    public GameObject Melee;
    public GameObject Lancer;
    public GameObject Shooter;


    public void OnMouseDown()
    {
        king = true;
        Invoke("switchCam", 0.5f);
        if(this.tag == "Lancer")
        {
            DataHolder.king = "Lancer";
        }
        if (this.tag == "Melee")
        {
            DataHolder.king = "Melee";
        }
        if (this.tag == "Shooter")
        {
            DataHolder.king = "Shooter";
        }

        if (this.tag == "Lancer1")
        {
            DataHolder.king2 = "Lancer";
            SceneManager.LoadScene("SampleScene");
        }
        if (this.tag == "Melee1")
        {
            DataHolder.king2 = "Melee";
            SceneManager.LoadScene("SampleScene");
        }
        if (this.tag == "Shooter1")
        {
            DataHolder.king2 = "Shooter";
            SceneManager.LoadScene("SampleScene");
        }

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
