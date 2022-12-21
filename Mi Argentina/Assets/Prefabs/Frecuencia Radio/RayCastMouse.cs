using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMouse : MonoBehaviour
{
    Camera cam;
    public LayerMask mask1;
    public LayerMask mask2;
    public Animator perilla1;
    public Animator perilla2;
    public Animator dial;
    


    void Start()
    {      
        cam = Camera.main;
    }

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        CheckClic();

        // Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position,
        Color.blue);
    }

    void CheckClic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1f, mask1))
            {
                dial.SetBool("Atras", true);
                perilla1.SetBool("Perilla_1_girando", true);             
            }

            if (Physics.Raycast(ray, out hit, 1f, mask2))
            {
                dial.SetBool("Adelante", true);
                perilla2.SetBool("Perilla_2_girando", true);             
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine("Idle2");
            StartCoroutine("Stop2");
            StartCoroutine("Idle1");
            StartCoroutine("Stop");
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);
        perilla1.SetBool("Perilla_1_girando", false);
    }

    IEnumerator Stop2()
    {
        yield return new WaitForSeconds(0.2f);
        perilla2.SetBool("Perilla_2_girando", false);
    }

    IEnumerator Idle1()
    {
        yield return new WaitForSeconds(0.4f);
        dial.SetBool("Atras", false);
    }

    IEnumerator Idle2()
    {
        yield return new WaitForSeconds(0.4f);
        dial.SetBool("Adelante", false);
    }
}

