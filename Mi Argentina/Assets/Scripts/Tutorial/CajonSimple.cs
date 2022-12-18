using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajonSimple : MonoBehaviour
{

    [Header("Settings")]
    public float velocidad;
    public float cuandoAbre;

    [Header("Informativo")]
    public float difCajonAbierto;

    bool abierto = false;
    bool abriendo = false;
    bool cerrando = false;
    Vector3 posAbierto;

    Vector3 posCerrado;

    // Start is called before the first frame update
    void Start()
    {
        posCerrado = transform.localPosition;
        posAbierto = new Vector3(transform.localPosition.x, transform.localPosition.y  - cuandoAbre, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        //difCajonAbierto = posCerrado.y - transform.localPosition.y;

        if(abriendo)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posAbierto, Time.deltaTime * velocidad);
            if(Vector3.Distance(transform.localPosition, posAbierto) < 0.0001f)
            {
                abriendo = false;
                abierto = true;
            }
        }

        if(cerrando)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posCerrado, Time.deltaTime * velocidad);
            if(Vector3.Distance(transform.localPosition, posCerrado) < 0.0001f)
            {
                cerrando = false;
                abierto = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            AbreCierra();
        }


    }

    public void AbreCierra()
    {
        if(!abierto)
        {
            abriendo = true;
        }
        else
        {
            cerrando = true;
        }
    }
}
