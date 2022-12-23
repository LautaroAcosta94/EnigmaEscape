using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoDeGravedadMate : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

    bool mateEnMano = false;

    // Update is called once per frame
    void Update()
    {
        ApagarGravedad();
        EncendidoGravedad();
    }

    void ApagarGravedad()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Mate"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    //gameObject.transform.localScale = new Vector3(0.1679668f, 0.121061f, 0.1522376f);
                    mateEnMano = true;
                }
            }
        }
    }

    void EncendidoGravedad()
    {
        if (mateEnMano == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.3679668f, 0.321061f, 0.3522376f);
                mateEnMano = false;
            }
        }
    }
}
