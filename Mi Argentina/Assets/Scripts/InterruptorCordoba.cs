using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorCordoba : MonoBehaviour
{
    public GameObject cuboInterruptor;
    public Vector3 direccion;

    public AudioSource correcto;
    public AudioSource incorrecto;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.name == "Cordoba")
        {
            Debug.Log("Colocaste la provincia correcta en la caja");
            cuboInterruptor.transform.position += direccion;
            correcto.Play();
        }
        else
        {
            Debug.Log("La provincia colocada no es la correcta");
            incorrecto.Play();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.transform.gameObject.name == "Cordoba")
        {
            Debug.Log("Haz quitado la provincia de la caja");
            cuboInterruptor.transform.position -= direccion;
        }
    }
}
