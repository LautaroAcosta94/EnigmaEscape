using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copa : MonoBehaviour
{
    public float range = 5f;
    public Camera fpsCam;
    public GameObject chispas;
    public GameObject confeti;
    public GameObject poster;

    public AudioSource muchachos;
    public AudioSource pirotecnia;

    public GameObject textoCampeones;

    bool campeones = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        copaDelMundo();
    }
    void copaDelMundo()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Copa"))
            {
                if (Input.GetKeyDown(KeyCode.E) && campeones == false)
                {
                    muchachos.Play();
                    pirotecnia.Play();
                    chispas.SetActive(true);
                    confeti.SetActive(true);
                    poster.SetActive(true);
                    campeones = true;
                } 
                else if (Input.GetKeyDown(KeyCode.E) && campeones == true)
                {
                    textoCampeones.SetActive(true);
                    StartCoroutine("textoOFF");
                }
            }
        }
    }

    IEnumerator textoOFF()
    {
        yield return new WaitForSeconds(3);
        textoCampeones.SetActive(false);
    }
}
