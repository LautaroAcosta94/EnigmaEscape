using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterVoice : MonoBehaviour
{

    public AudioSource gmVoice;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;

    bool yaHablo = false;
    bool detectaJugador;

    // Update is called once per frame
    void Update()
    {
        DetectorJugador();

        if(detectaJugador == true)
        {
            if(yaHablo == false)
            {
                Debug.Log("Habla GM");
                gmVoice.Play();
                yaHablo = true;
            }
            
        }
    }

    void DetectorJugador()
    {
        detectaJugador = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDelJugador);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
