using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public float range = 50f;
    public Camera fpsCam;

    public Transform mano;

    public bool manoOcupada = false;


    void Update()
    {

        /*
            0 = Click Izquierdo
            1 = Click Derecho
            2 = Ruedita
        */

        if(Input.GetMouseButtonDown(0))
        {
            AgarrarObjeto();
        }
        if(Input.GetMouseButtonUp(0))
        {
            manoOcupada = false;
        }
        
    }

    void AgarrarObjeto()
    {
        RaycastHit hit;

        if(manoOcupada == false)
        {

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                if(hit.transform.CompareTag("Provincias"))
                {
                    Debug.Log("Agarraste Provincia");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                }
            }

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                if(hit.transform.CompareTag("Llave"))
                {
                    Debug.Log("Agarraste Llave");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                }
            }

        }
    }


}
