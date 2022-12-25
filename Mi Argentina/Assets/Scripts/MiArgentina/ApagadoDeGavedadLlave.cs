using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoDeGavedadLlave : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool llaveEnMano = false;

    GameObject llaveAgarrada;

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
            if(hit.transform.CompareTag("Llave"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    llaveAgarrada = hit.transform.gameObject;
                    llaveAgarrada.GetComponent<Rigidbody>().isKinematic = true;
                    llaveAgarrada.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
                    llaveEnMano = true;
                }
            }

            if(hit.transform.CompareTag("LlaveArmario"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    llaveAgarrada = hit.transform.gameObject;
                    llaveAgarrada.GetComponent<Rigidbody>().isKinematic = true;
                    llaveAgarrada.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
                    llaveEnMano = true;
                }
            }

            if(hit.transform.CompareTag("LlaveDormitorio"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    llaveAgarrada = hit.transform.gameObject;
                    llaveAgarrada.GetComponent<Rigidbody>().isKinematic = true;
                    llaveAgarrada.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
                    llaveEnMano = true;
                }
            }

            if(hit.transform.CompareTag("CajonConLlave") && llaveEnMano == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    llaveEnMano = false;
                }
            }

            if(hit.transform.CompareTag("PuertaArmario2") && llaveEnMano == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    llaveEnMano = false;
                }
            }

            if(hit.transform.CompareTag("PuertaDormitorio") && llaveEnMano == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    llaveEnMano = false;
                }
            }
        }
    }

    
    void EncendidoGravedad()
    {
        if(llaveEnMano == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                llaveAgarrada.GetComponent<Rigidbody>().isKinematic = false;
                llaveAgarrada.transform.SetParent(null);
                llaveAgarrada.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
                llaveEnMano = false;
            }
        }
        if(llaveEnMano == false)
        {
            llaveAgarrada = null;
        }
    }
}
