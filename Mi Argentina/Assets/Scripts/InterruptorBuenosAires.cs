using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorBuenosAires : MonoBehaviour
{

    //public GameObject cuboInterruptor;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.gameObject.name == "BuenosAires")
        {
            Debug.Log("Colocaste la provincia correcta en la caja");
        }
        else
        {
            Debug.Log("La provincia colocada no es la correcta");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.transform.gameObject.name == "BuenosAires")
        {
            Debug.Log("Haz quitado la provincia de la caja");
        }
    }
}