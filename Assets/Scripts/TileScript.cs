using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isHighGround, isAvailable;
    public Material HG;
    void Start()
    {
        //gameObject.GetComponent<TileScript>().isHighGround = 0;
        Vector3 HexPos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (isHighGround)
        {
            gameObject.GetComponent<MeshRenderer>().material = HG;
        }
    }
}
