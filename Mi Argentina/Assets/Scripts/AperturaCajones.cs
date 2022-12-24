using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AperturaCajones : MonoBehaviour
{
    [Header("Settings")]
    public float velocidad;
    public Vector3 posAbierto;
    public float cuantoAbre;

    [Header("Informativo")]
    public float difCajonAbierto;

    bool abierto = false;
    bool abriendo = false;
    bool cerrando = false;
    Vector3 posCerrado;

    public AudioSource cajonAbierto;
    public AudioSource cajonCerrado;


    void Start()
    {
        posCerrado = transform.localPosition;
        posAbierto = new Vector3(transform.localPosition.x, transform.localPosition.y - cuantoAbre, transform.localPosition.z);
    }

    void Update()
    {
        //difCajonAbierto = posCerrado.y - transform.localPosition.y;
        
        if (abriendo)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posAbierto, Time.deltaTime * velocidad);
            if (Vector3.Distance(transform.localPosition, posAbierto) < 0.0001f)
            {
                abriendo = false;
                abierto = true;
            }
        }

        if (cerrando)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posCerrado, Time.deltaTime * velocidad);
            if (Vector3.Distance(transform.localPosition, posCerrado) < 0.0001f)
            {
                cerrando = false;
                abierto = false;
            }
        }  
    }

    public void AbreCierra()
    {
        if (abierto == false)
        {
            cajonAbierto.Play();
            abriendo = true;
        }
        else
        {
            cajonCerrado.Play();
            cerrando = true;
        }
    }
}
