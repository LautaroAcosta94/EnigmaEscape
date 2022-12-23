using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : MonoBehaviour
{
    static public bool placaMesa = false;
    public GameObject botonMesa;
    public BoxCollider placa;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.CompareTag("Placa"))
        {
            placaMesa = false;
            botonMesa.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.transform.gameObject.CompareTag("Placa"))
        {
            placaMesa = true;
            botonMesa.GetComponent<Renderer>().material.color = Color.green;
            Destroy(placa);
        }
    }
}
