using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Radio : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;
    public GameObject Radi;
    public AudioSource encendido;
    public bool encender = false;

    void Update()
    {

        /*
            0 = Click Izquierdo
            1 = Click Derecho
            2 = Ruedita
        */

        if (Input.GetKeyDown(KeyCode.E))
        {
            EncenderRadio();
        }

    }

    void EncenderRadio()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Radio") && encender == false)
            {
                encendido.Play();
                encender = true;
            }
            else
            {
                encendido.Stop();
                encender = false;
            }
        }
    }

}

