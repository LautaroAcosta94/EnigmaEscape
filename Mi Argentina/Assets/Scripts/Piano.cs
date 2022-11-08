using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Piano : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;
    public GameObject Pian;
    public bool encender = false;
    public GameObject cam1;
    public GameObject cam2;

    void Update()
    {

        /*
            0 = Click Izquierdo
            1 = Click Derecho
            2 = Ruedita
        */

        if (Input.GetKeyDown(KeyCode.E))
        {
            Tocar();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NoTocar();
        }

    }

    void NoTocar()
    {
        if (encender == true && cam2.activeInHierarchy)
        {
            Cursor.visible = false;
            cam1.SetActive(true);
            cam2.SetActive(false);
            encender = false;
        }
    }

void Tocar()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Piano") && encender == false && cam1.activeInHierarchy)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                cam1.SetActive(false);
                cam2.SetActive(true);
                encender = true;
            }
        }
    }
}
