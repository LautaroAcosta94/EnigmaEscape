using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public float range = 1.5f;
    public Camera fpsCam;
    public GameObject Tele;
    public bool encender = false;
    public AudioSource TV_ON;
    public AudioSource TV_OFF;

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
            if (hit.transform.CompareTag("TV"))
            {
                if (!encender)
                {
                    TV_ON.Play();                                  
                    Tele.SetActive(true);
                    encender = true;
                    //Tele.GetComponent<VideoPlayer>().enabled = true;
                }
                else
                {                 
                    TV_OFF.Play();                    
                    Tele.SetActive(false);
                    encender = false;
                    //Tele.GetComponent<VideoPlayer>().enabled = false;
                }
            }
        }
    }

}
