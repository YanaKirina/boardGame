using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class choosehero2 : MonoBehaviour
{
    [Header("Set in inspector")]
    public UnityEngine.UI.Button button;
    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;
    public TextMeshProUGUI t3;
    public GameObject Hero3;
    public GameObject h3p1t1;
    public GameObject h3p2t1;
    public GameObject h3p3t1;
    public GameObject h3p4t1;
    public GameObject h3p5t1;
    public GameObject h3p1t2;
    public GameObject h3p2t2;
    public GameObject h3p3t2;
    public GameObject h3p4t2;
    public GameObject h3p5t2;
    public int chekerClick;
    public GameObject[] heroes3;


    private void Awake()
    {
        Vector3 position = Hero3.transform.position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        Hero3.transform.position = position;
    }

    public void onClick2()
    {
        chekerClick += 1;
        Debug.Log("клик");
    }

    private void OnMouseDown()
    {

        if ((Convert.ToInt32(t3.text) - 1) >= 0 && Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) >= 8)
        {
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
            {
                Vector3 position = Hero3.transform.position;
                position.x = -80;
                position.y = -94;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position1 = h3p1t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -180;
                h3p1t1.transform.position = position1;
                Instantiate(h3p1t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
                {
                    heroes3[0] = h3p1t1;
                    DataHolder.hero1 = 3;
                }
                else
                {
                    heroes3[0] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
            {
                Vector3 position = Hero3.transform.position;
                position.x = -40;
                position.y = -94;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position1 = h3p2t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -215;
                h3p2t1.transform.position = position1;
                Instantiate(h3p2t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
                {
                    heroes3[1] = h3p2t1;
                    DataHolder.hero2 = 3;
                }
                else
                {
                    heroes3[1] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
            {
                Vector3 position = Hero3.transform.position;
                position.x = 0;
                position.y = -94;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position1 = h3p3t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -250;
                h3p3t1.transform.position = position1;
                Instantiate(h3p3t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
                {
                    heroes3[2] = h3p3t1;
                    DataHolder.hero3 = 3;
                }
                else
                {
                    heroes3[2] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
            {
                Vector3 position = Hero3.transform.position;
                position.x = 40;
                position.y = -94;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position1 = h3p4t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -285;
                h3p4t1.transform.position = position1;
                Instantiate(h3p4t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
                {
                    heroes3[3] = h3p4t1;
                    DataHolder.hero4 = 3;
                }
                else
                {
                    heroes3[3] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
            {
                Vector3 position = Hero3.transform.position;
                position.x = 80;
                position.y = -94;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position1 = h3p5t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -320;
                h3p5t1.transform.position = position1;
                Instantiate(h3p5t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
                {
                    heroes3[4] = h3p5t1;
                    DataHolder.hero5 = 3;
                }
                else
                {
                    heroes3[4] = null;
                }
            }
            t3.text = Convert.ToString(Convert.ToInt32(t3.text) - 1);
        }
        if ((Convert.ToInt32(t3.text) - 1) >= 0 && Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) >= 3 && chekerClick >= 1)
        { 
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 7)
            {
                Vector3 position = Hero3.transform.position;
                position.x = -80;
                position.y = 60;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position2 = h3p1t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -320;
                h3p1t2.transform.position = position2;
                Instantiate(h3p1t2);
                DataHolder.hero1t2 = 6;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 6)
            {
                Vector3 position = Hero3.transform.position;
                position.x = -40;
                position.y = 60;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position2 = h3p2t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -285;
                h3p2t2.transform.position = position2;
                Instantiate(h3p2t2);
                DataHolder.hero2t2 = 6;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 5)
            {
                Vector3 position = Hero3.transform.position;
                position.x = 0;
                position.y = 60;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position2 = h3p3t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -250;
                h3p3t2.transform.position = position2;
                Instantiate(h3p3t2);
                DataHolder.hero3t2 = 6;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 4)
            {
                Vector3 position = Hero3.transform.position;
                position.x = 40;
                position.y = 60;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position2 = h3p4t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -215;
                h3p4t2.transform.position = position2;
                Instantiate(h3p4t2);
                DataHolder.hero4t2 = 6;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 3)
            {
                Vector3 position = Hero3.transform.position;
                position.x = 80;
                position.y = 60;
                Hero3.transform.position = position;
                Instantiate(Hero3);

                Vector3 position2 = h3p5t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -180;
                h3p5t2.transform.position = position2;
                Instantiate(h3p5t2);
                DataHolder.hero5t2 = 6;
            }
            t3.text = Convert.ToString(Convert.ToInt32(t3.text) - 1);

        }
    
    }
}
