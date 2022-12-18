using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AperturaDePuerta : MonoBehaviour
{
    public GameObject puerta;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public LayerMask capaDeLaLlave;
    public float angulo;

    bool detectaJugador = false;
    bool detectaLlave = false;

    public AudioSource puertaAbierta;


    // Update is called once per frame
    void Update()
    {
      Detector();
      
      if(detectaJugador == true)
      {
        Debug.Log("Detecta un jugador");

        if(detectaLlave == true)
        {
            Debug.Log("El jugador tiene llave");

            if(Input.GetKeyDown(KeyCode.E))
            {
                puerta.transform.rotation = Quaternion.Euler(0, -angulo, 0);
                puertaAbierta.Play();
            }
        }
      }
    }

    void AbrirPuerta()
    {
        
    }

    void Detector()
    {
        detectaJugador = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDelJugador);
        detectaLlave = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeLaLlave);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
