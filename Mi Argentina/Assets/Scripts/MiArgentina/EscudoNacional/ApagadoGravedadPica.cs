using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoGravedadPica : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool picaEnMano = false;

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
            if(hit.transform.CompareTag("PicaEscudoNacional"))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.localScale = new Vector3(0.17806f, 0.17806f, 0.17806f);
                    picaEnMano = true;
                }
            }
        }
    }

    
    void EncendidoGravedad()
    {
        if(picaEnMano == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.17806f, 0.17806f, 0.17806f);
                picaEnMano = false;
            }
        }
    }
}