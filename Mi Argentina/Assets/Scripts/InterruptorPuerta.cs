using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPuerta : MonoBehaviour
{
    //Variables
    
    public bool verificar = false;
    public float angulo;
    public GameObject puerta;

    //Sonidos Puertas
    public AudioSource puertaAbriendo;
    public AudioSource puertaCerrada;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.name == "Player")
        {
                puerta.transform.rotation = Quaternion.Euler(0, -angulo, 0);
                puertaAbriendo.Play();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.transform.gameObject.name == "Player")
        {
                puerta.transform.rotation = Quaternion.Euler(0, 0, 0);
                puertaCerrada.Play();
        }
    }

}
