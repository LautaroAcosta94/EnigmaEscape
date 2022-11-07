using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorPuertaDos : MonoBehaviour
{
    //Variables
    
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

    void OnTriggerStay(Collider col)
    {
        if(col.transform.gameObject.name == "PlayerInt")
        {
                Debug.Log("Se detecto cubo");
                puerta.transform.rotation = Quaternion.Euler(0, -angulo, 0);
        }
    }


}
