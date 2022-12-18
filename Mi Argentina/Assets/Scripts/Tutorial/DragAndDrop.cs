using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;

    public Transform mano;

    public bool manoOcupada = false;
    bool agarrasteLlave = false;

    //Sonidos
    public AudioSource agarraObjeto;
    public AudioSource sueltaObjeto;

    //Variables para apertura de Cajon2
    public Animator aperturaCajon2;
    bool cajon2Abierto = false;

    void Update()
    {

        /*
            0 = Click Izquierdo
            1 = Click Derecho
            2 = Ruedita
        */
        UsarLlave();
        if(Input.GetMouseButtonDown(0))
        {
            AgarrarObjeto();
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(manoOcupada == true)
            {
                sueltaObjeto.Play();
                manoOcupada = false;
            }

        }
        
    }

    void AgarrarObjeto()
    {
        RaycastHit hit;

        if(manoOcupada == false)
        {

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                //hit provincias
                if (hit.transform.CompareTag("Provincias"))
                {
                    Debug.Log("Agarraste Provincia");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarraObjeto.Play();
                }

                //hit llave
                if (hit.transform.CompareTag("Llave"))
                {
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteLlave = true;
                }


            }
        }
    }

    void UsarLlave()
    {
        if(agarrasteLlave == true)
        {
            Debug.Log("Agarraste Llave");
            RaycastHit hit2;

            if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Llave");
                agarrasteLlave = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit2, range))
            {
                if(hit2.transform.CompareTag("CajonConLlave"))
                {
                    Debug.Log("Puedes Abrir el Cajon");
                }
            }
        }
    }

}
