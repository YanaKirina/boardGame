using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class camSwitcher : MonoBehaviour
{
    public GameObject cam1;
    public Camera mainCamera;

    private void Awake()
    {
        mainCamera.gameObject.SetActive(true);
        cam1.gameObject.SetActive(true);
    }

    public void OnClickSwitcher()
    {
        Instantiate(cam1);
        mainCamera.gameObject.SetActive(false);

    }
}
