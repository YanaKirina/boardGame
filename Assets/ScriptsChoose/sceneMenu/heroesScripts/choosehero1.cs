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
    public GameObject Hero2, h2p1t1, h2p2t1, h2p3t1, h2p4t1, h2p5t1, h2p1t2, h2p2t2, h2p3t2, h2p4t2, h2p5t2;
    public int chekerClick;
    public GameObject[] heroes2;


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
        Debug.Log("клик");
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

                Vector3 position1 = h2p1t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -180;
                h2p1t1.transform.position = position1;
                Instantiate(h2p1t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 12)
                {
                    heroes2[0] = h2p1t1;
                    DataHolder.hero1 = 2;
                }
                else
                {
                    heroes2[0] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
            {
                Vector3 position = Hero2.transform.position;
                position.x = -40;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = h2p2t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -215;
                h2p2t1.transform.position = position1;
                Instantiate(h2p2t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 11)
                {
                    heroes2[1] = h2p2t1;
                    DataHolder.hero2 = 2;
                }
                else
                {
                    heroes2[1] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 0;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = h2p3t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -250;
                h2p3t1.transform.position = position1;
                Instantiate(h2p3t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 10)
                {
                    heroes2[2] = h2p3t1;
                    DataHolder.hero3 = 2;
                }
                else
                {
                    heroes2[2] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 40;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = h2p4t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -285;
                h2p4t1.transform.position = position1;
                Instantiate(h2p4t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 9)
                {
                    heroes2[3] = h2p4t1;
                    DataHolder.hero4 = 2;
                }
                else
                {
                    heroes2[3] = null;
                }
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 80;
                position.y = -94;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position1 = h2p5t1.transform.position;
                position1.x = 25;
                position1.y = -20;
                position1.z = -320;
                h2p5t1.transform.position = position1;
                Instantiate(h2p5t1);
                if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 8)
                {
                    heroes2[4] = h2p5t1;
                    DataHolder.hero5 = 2;
                }
                else
                {
                    heroes2[4] = null;   
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

                Vector3 position2 = h2p1t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -320;
                h2p1t2.transform.position = position2;
                Instantiate(h2p1t2);
                DataHolder.hero1t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 6)
            {
                Vector3 position = Hero2.transform.position;
                position.x = -40;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = h2p2t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -285;
                h2p2t2.transform.position = position2;
                Instantiate(h2p2t2);
                DataHolder.hero2t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 5)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 0;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = h2p3t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -250;
                h2p3t2.transform.position = position2;
                Instantiate(h2p3t2);
                DataHolder.hero3t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 4)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 40;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = h2p4t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -215;
                h2p4t2.transform.position = position2;
                Instantiate(h2p4t2);
                DataHolder.hero4t2 = 5;
            }
            if (Convert.ToInt32(t1.text) + Convert.ToInt32(t2.text) + Convert.ToInt32(t3.text) == 3)
            {
                Vector3 position = Hero2.transform.position;
                position.x = 80;
                position.y = 60;
                Hero2.transform.position = position;
                Instantiate(Hero2);

                Vector3 position2 = h2p5t2.transform.position;
                position2.x = -25;
                position2.y = -20;
                position2.z = -180;
                h2p5t2.transform.position = position2;
                Instantiate(h2p5t2);
                DataHolder.hero5t2 = 5;
            }
            t2.text = Convert.ToString(Convert.ToInt32(t2.text) - 1);

        }
    }

}
