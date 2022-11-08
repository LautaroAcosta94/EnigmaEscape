using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;
    public GameObject Tele;
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
            EncenderTV();
        }

    }

    void EncenderTV()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("TV") && encender == false)
            {
                Tele.GetComponent<VideoPlayer>().enabled = true;
                encender = true;
            }
            else
            {
                Tele.GetComponent<VideoPlayer>().enabled = false;
                encender = false;
            }
        }
    }

}
