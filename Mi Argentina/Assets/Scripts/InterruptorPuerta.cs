using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPuerta : MonoBehaviour
{
    //Variables

    public float tiempo = 0;
    public bool verificar = false;
    public float angulo;
    public GameObject puerta;

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
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.transform.gameObject.name == "Player")
        {
                puerta.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}