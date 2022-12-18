using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagandoGravedadLlave : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.SetParent(null);
            gameObject.transform.localScale = new Vector3(0.0770744f, 0.0770744f, 0.0770744f);
        }
    }

}
