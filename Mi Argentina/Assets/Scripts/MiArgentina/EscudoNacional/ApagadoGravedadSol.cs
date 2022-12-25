using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoGravedadSol : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool solEnMano = false;

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
            if(hit.transform.CompareTag("SolEscudoNacional"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.localScale = new Vector3(0.17806f, 0.17806f, 0.17806f);
                    solEnMano = true;
                }
            }
        }
    }

    
    void EncendidoGravedad()
    {
        if(solEnMano == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.17806f, 0.17806f, 0.17806f);
                solEnMano = false;
            }
        }
    }
}
