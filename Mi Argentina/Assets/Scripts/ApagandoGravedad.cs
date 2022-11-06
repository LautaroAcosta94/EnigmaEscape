using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagandoGravedad : MonoBehaviour
{

    public GameObject provincia;
    bool objetoEnCajaBsAs = false;
    bool objetoEnCajaCor = false;
    bool objetoEnCajaER = false;
    bool objetoEnCajaSan = false;

    void Update()
    {
        if(objetoEnCajaBsAs == false && provincia.name == "BuenosAires")
        {
            ApagadoDeGravedad();
        }

        if(objetoEnCajaCor == false && provincia.name == "Cordoba")
        {
            ApagadoDeGravedad();
        }

        if(objetoEnCajaER == false && provincia.name == "EntreRios")
        {
            ApagadoDeGravedad();
        }

        if(objetoEnCajaSan == false && provincia.name == "SantiagoDelEstero")
        {
            ApagadoDeGravedad();
        }
    }

    void OnTriggerEnter(Collider col)
    {
            if(col.transform.gameObject.name == "DetCajBsAs" && provincia.name == "BuenosAires")
            {
                objetoEnCajaBsAs = true;
            }
    }

    void ApagadoDeGravedad()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.SetParent(null);
            gameObject.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
        }
    }

}
