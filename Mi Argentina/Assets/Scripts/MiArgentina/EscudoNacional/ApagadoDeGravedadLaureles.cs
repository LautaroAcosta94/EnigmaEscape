using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoDeGravedadLaureles : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool laurelesEnMano = false;

    public GameObject laurelesback;

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
            if(hit.transform.CompareTag("LaurelesEscudoNacional"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.transform.localScale = new Vector3(0.17806f, 0.17806f, 0.17806f);
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    laurelesback.GetComponent<BoxCollider>().isTrigger = true;
                    laurelesEnMano = true;
                }
            }
        }
    }

    
    void EncendidoGravedad()
    {
        if(laurelesEnMano == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                laurelesback.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.17806f, 0.17806f, 0.17806f);
                laurelesEnMano = false;
            }
        }
    }
}
