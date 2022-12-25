using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoGravedadOvalo : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool ovaloEnMano = false;

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
            if(hit.transform.CompareTag("OvaloEscudoNacional"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.transform.localScale = new Vector3(0.1166827f, 0.1166827f, 0.1166827f);
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    ovaloEnMano = true;
                }
            }
        }
    }

    
    void EncendidoGravedad()
    {
        if(ovaloEnMano == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.1166827f, 0.1166827f, 0.1166827f);
                ovaloEnMano = false;
            }
        }
    }
}