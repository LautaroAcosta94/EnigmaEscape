using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public bool pausaActiva;
    public static bool noPausa = false;
    public GameObject menuPausa;
    public GameObject gameOver;
    public GameObject camaraPausa;
    public GameObject player;
    public AudioSource musicaAmbiente;



    // Start is called before the first frame update
    void Start()
    {
        noPausa = false;
        menuPausa.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        TogglePausa();
    }
    public void TogglePausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (noPausa == false)
            {
                if (pausaActiva)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();                 
                }
            }
            else Debug.Log("No Pausa");
        }
    }

    public void PauseGame()
    {
        musicaAmbiente.volume = 0.1f;
        menuPausa.SetActive(true);
        pausaActiva = true;
        player.SetActive(false);
        camaraPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        musicaAmbiente.volume = 0.3f;
        menuPausa.SetActive(false);
        pausaActiva = false;
        player.SetActive(true);
        camaraPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PausaLocked()
    {
        noPausa = false;
    }

    void GameOver()
    {
        if (TimeController.enMarcha == false)
        {
            musicaAmbiente.Stop();
            noPausa = true;
            menuPausa.SetActive(false);
            gameOver.SetActive(true);
            player.SetActive(false);
            camaraPausa.SetActive(true);
        }
    }
}
