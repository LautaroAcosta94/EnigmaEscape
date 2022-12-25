using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Piano : MonoBehaviour
{
    public float range = 5f;
    public Camera fpsCam;
    public GameObject collider_piano;
    public GameObject camara_piano;
    public GameObject player;
    public AudioSource musicaAmbiente;

    void Update()
    {

        /*
            0 = Click Izquierdo
            1 = Click Derecho
            2 = Ruedita
        */

        Tocar();
    }

    void Tocar()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Piano"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    musicaAmbiente.Pause();
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    player.SetActive(false);
                    camara_piano.SetActive(true);
                    Pausa.noPausa = true;
                }
            }
        }
    }
}