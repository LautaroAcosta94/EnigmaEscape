using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarPartida : MonoBehaviour
{
  public void Iniciar()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MiArgentina");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
