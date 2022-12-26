using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosFinales : MonoBehaviour
{
    public GameObject textoAdelantar;
    public float temporizador = 67;

    // Start is called before the first frame update
    void Start()
    {
        temporizador = 67;
    }

    // Update is called once per frame
    void Update()
    {
        temporizador -= Time.deltaTime;
        CuentaRegresiva();
        ActivarTexto();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    void CuentaRegresiva()
    {
        if (temporizador <= 0)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
        
    }

    void ActivarTexto()
    {
        if (temporizador <= 30)
        {
            textoAdelantar.SetActive(true);
        }    
    }
}
