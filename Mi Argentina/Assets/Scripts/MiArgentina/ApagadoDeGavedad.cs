using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoDeGavedad : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    GameObject provinciaAgarrada;

    bool provinciaEnMano = false;

    // Update is called once per frame
    void Update()
    {
        ApagarGravedad();
        EncendidoGravedad();
    }

    void ApagarGravedad()
    {
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.CompareTag("Provincias"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                        provinciaAgarrada = hit.transform.gameObject;
                        provinciaAgarrada.GetComponent<Rigidbody>().isKinematic = true;
                        provinciaAgarrada.GetComponent<MeshCollider>().isTrigger = true;
                        provinciaAgarrada.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                        provinciaEnMano = true;
                }
            }

            if(hit.transform.CompareTag("CuadroMapaArg") && provinciaEnMano == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    provinciaEnMano = false;
                }
            }
        }
    }

    void EncendidoGravedad()
    {   
        if(provinciaEnMano == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                provinciaAgarrada.GetComponent<Rigidbody>().isKinematic = false;
                provinciaAgarrada.GetComponent<MeshCollider>().isTrigger = false;
                provinciaAgarrada.transform.SetParent(null);
                provinciaAgarrada.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                //provinciaAgarrada = null;
                provinciaEnMano = false;
            }
            if(provinciaEnMano == false)
            {
                provinciaAgarrada = null;
            }
        }

    }
}
