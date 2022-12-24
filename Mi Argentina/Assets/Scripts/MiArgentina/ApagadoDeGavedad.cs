using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagadoDeGavedad : MonoBehaviour
{

    public float range = 5f;
    public Camera fpsCam;

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
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<MeshCollider>().isTrigger = true;
                    gameObject.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    provinciaEnMano = true;
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
                gameObject.GetComponent<MeshCollider>().isTrigger = false;
                gameObject.transform.SetParent(null);
                gameObject.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                provinciaEnMano = false;
            }
        }
    }
}
