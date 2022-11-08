using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Creditos : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;
    public GameObject creditos;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject creditosfinales;
    public GameObject musicaOFF;

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

    }

  

    void Tocar()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Creditos") && cam1.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
                cam1.SetActive(false);
                musicaOFF.GetComponent<AudioSource>().Stop();
                creditosfinales.GetComponent<VideoPlayer>().Play();
                cam2.SetActive(true);
            }
        }
    }
}
