using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_Botones : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MiArgentina");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
