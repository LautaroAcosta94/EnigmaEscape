using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_Botones : MonoBehaviour
{
    public Animator crossfade;
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MiArgentina");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        StartCoroutine("Salir");
    }

    IEnumerator Salir()
    {
        crossfade.SetBool("Open", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuPrincipal");
    }

}
