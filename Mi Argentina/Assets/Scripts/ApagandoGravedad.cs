using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagandoGravedad : MonoBehaviour
{

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.SetParent(null);
        }
    }

}
