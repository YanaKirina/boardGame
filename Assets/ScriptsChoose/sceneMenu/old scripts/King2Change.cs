using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class King2Change : MonoBehaviour
{
    public bool king2;

    public void OnMouseDown()
    {
        king2 = true;
        print("lox");
        SceneManager.LoadScene("Game");
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
