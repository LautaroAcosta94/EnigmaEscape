using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoDeGavedad : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool provinciaEnMano = false;
    bool llaveEnMano = false;

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
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    provinciaEnMano = true;
                }
            }

            if(hit.transform.CompareTag("Llave"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
                    llaveEnMano = true;
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
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                provinciaEnMano = false;
            }
        }

        if(llaveEnMano == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.SetParent(null);
            gameObject.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
            llaveEnMano = false;
        }
    }
}
