using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class choosehero1 : MonoBehaviour
{
    [Header("Set in inspector")]
    public UnityEngine.UI.Button button;
    public TextMeshProUGUI t1, t2, t3;
    public GameObject Hero2, Melee, Melee1;
    public int chekerClick;


    private void Awake()
    {
        Vector3 position = Hero2.transform.position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        Hero2.transform.position = position;
    }

    public void onClick1()
    {
        chekerClick += 1;
        Debug.Log("����");
    }

    private void OnMouseDown()
    {

        if ((Convert.ToInt32(t2.text) - 1) >= 0 && Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) >= 8)
        {
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
            {
                Vector3 position = Hero2.transform.position;
                position.x = -80;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = Melee.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -180;
                Melee.transform.position = position1;
                Instantiate(Melee);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
                {
                    DataHolder.hero1 = 2;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
            {
                Vector3 position = Hero2.transform.position;
                position.x = -40;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = Melee.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -215;
                Melee.transform.position = position1;
                Instantiate(Melee);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
                {;
                    DataHolder.hero2 = 2;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 0;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = Melee.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -250;
                Melee.transform.position = position1;
                Instantiate(Melee);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
                {
                    DataHolder.hero3 = 2;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 40;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = Melee.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -285;
                Melee.transform.position = position1;
                Instantiate(Melee);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
                {
                    DataHolder.hero4 = 2;
                }
                else
                {
                    Debug.Log("Error");
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 80;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = Melee.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -320;
                Melee.transform.position = position1;
                Instantiate(Melee);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
                {
                    DataHolder.hero5 = 2;
                }
                else
                {
                    Debug.Log("Error");   
                }
            }
            t2.text = Convert.ToString(Convert.ToInt32(t2.text) - 1);
        }
        if ((Convert.ToInt32(t2.text) - 1) >= 0 && Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) >= 3 && chekerClick >= 1)
        {
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 7)
            {
                Vector3 position = Hero2.transform.position;
                position.x = -80;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = Melee1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -320;
                Melee1.transform.position = position2;
                Instantiate(Melee1);
                DataHolder.hero1t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 6)
            {
                Vector3 position = Hero2.transform.position;
                position.x = -40;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = Melee1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -285;
                Melee1.transform.position = position2;
                Instantiate(Melee1);
                DataHolder.hero2t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 5)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 0;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = Melee1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -250;
                Melee1.transform.position = position2;
                Instantiate(Melee1);
                DataHolder.hero3t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 4)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 40;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = Melee1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -215;
                Melee1.transform.position = position2;
                Instantiate(Melee1);
                DataHolder.hero4t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 3)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 80;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = Melee1.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -180;
                Melee1.transform.position = position2;
                Instantiate(Melee1);
                DataHolder.hero5t2 = 5;
            }
            t2.text = Convert.ToString(Convert.ToInt32(t2.text) - 1);

        }
    }

}
