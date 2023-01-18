using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class chosehero : MonoBehaviour
{
    [Header("Set in inspector")]
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Button button2;
    public TextMeshProUGUI t1, t2, t3;
    public GameObject Hero1, Lancer, Lancer1 ;
    public int chekerClick = 0;



    private void Awake()
    {
        Vector3 position = Hero1.transform.position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        Hero1.transform.position = position;

        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);       
    }
    private void Update()
    {
        if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 7)
        {
            button.gameObject.SetActive(true);
        }

        if (chekerClick >= 1)
        {
            button.gameObject.SetActive(false);
        }

        if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 2)
        {
            button2.gameObject.SetActive(true);
        }


    }
    public void onClick()
    {
        chekerClick += 1;
        Debug.Log("клик");
    }
    private void OnMouseDown()
    {

        if ((Convert.ToInt32(t1.text) - 1) >= 0 && Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) >= 8)
        {

            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
            {
                Vector3 position = Hero1.transform.position;
                position.x = -80;
                position.y = -94;
                Hero1.transform.position = position;
                Instantiate(Hero1);
                
                Vector3 position1 = Lancer.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -180;
                Lancer.transform.position = position1;
                Instantiate(Lancer);
                if(Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
                {
                    DataHolder.hero1 = 1;                    
                }
                else
                {
                    Debug.Log("Error");
                }

            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
            {
                Vector3 position = Hero1.transform.position;
                position.x = -40;
                position.y = -94;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position1 = Lancer.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -215;
                Lancer.transform.position = position1;
                Instantiate(Lancer);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
                {
                    DataHolder.hero2 = 1;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
            {
                Vector3 position = Hero1.transform.position;
                position.x = 0;
                position.y = -94;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position1 = Lancer.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -250;
                Lancer.transform.position = position1;
                Instantiate(Lancer);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
                {
                    DataHolder.hero3 = 1;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
            {
                Vector3 position = Hero1.transform.position;
                position.x = 40;
                position.y = -94;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position1 = Lancer.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -285;
                Lancer.transform.position = position1;
                Instantiate(Lancer);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
                {
                    DataHolder.hero4 = 1;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
            {
                Vector3 position = Hero1.transform.position;
                position.x = 80;
                position.y = -94;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position1 = Lancer.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -320;
                Lancer.transform.position = position1;
                Instantiate(Lancer);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
                {
                    DataHolder.hero5 = 1;
                }
                else
                {
                    Debug.Log("Error");
                }
            }   
            t1.text = Convert.ToString(Convert.ToInt32(t1.text) - 1);
        }
        if ((Convert.ToInt32(t1.text) - 1) >= 0 && Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) >= 3 && chekerClick >= 1)
        {
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 7)
            {
                Vector3 position = Hero1.transform.position;
                position.x = -80;
                position.y = 60;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position2 = Lancer1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -320;
                Lancer1.transform.position = position2;
                Instantiate(Lancer1);
                DataHolder.hero1t2 = 4;

            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 6)
            {
                Vector3 position = Hero1.transform.position;
                position.x = -40;
                position.y = 60;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position2 = Lancer1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -285;
                Lancer1.transform.position = position2;
                Instantiate(Lancer1);
                DataHolder.hero2t2 = 4;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 5)
            {
                Vector3 position = Hero1.transform.position;
                position.x = 0;
                position.y = 60;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position2 = Lancer1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -250;
                Lancer1.transform.position = position2;
                Instantiate(Lancer1);
                DataHolder.hero3t2 = 4;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 4)
            {
                Vector3 position = Hero1.transform.position;
                position.x = 40;
                position.y = 60;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position2 = Lancer1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -215;
                Lancer1.transform.position = position2;
                Instantiate(Lancer1);
                DataHolder.hero4t2 = 4;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 3)
            {
                Vector3 position = Hero1.transform.position;
                position.x = 80;
                position.y = 60;
                Hero1.transform.position = position;
                Instantiate(Hero1);

                Vector3 position2 = Lancer1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -180;
                Lancer1.transform.position = position2;
                Instantiate(Lancer1);
                DataHolder.hero5t2 = 4;
            }
            t1.text = Convert.ToString(Convert.ToInt32(t1.text) - 1);
        }
    }
}         
        
        
    


    
