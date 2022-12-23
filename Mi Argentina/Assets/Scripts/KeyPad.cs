using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] public Text Ans;
    [SerializeField] public Animator Door;
    public string Answer = "1986";

    public GameObject camara_panel;
    public GameObject player;
    public BoxCollider panel;
    public BoxCollider manija;

    public AudioSource cajaAbierta;
    public AudioSource codigoCorrecto;
    public AudioSource codigoIncorrecto;

    public GameObject textoCaja;

    void Update()
    {
        textoCaja.SetActive(false);
    }

    public void Number(int number)
    {
        Ans.text += number.ToString(); 
    }

    public void Enter()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correcto";           
            panel.enabled = false;
            manija.enabled = false;
            codigoCorrecto.Play();
            StartCoroutine("cambioCamaras");
        }
        else
        {
            Ans.text = "Invalido";
            codigoIncorrecto.Play();
        }
    }

    public void Borrar()
    {
        Ans.text = "";
    }

    IEnumerator cambioCamaras()
    {
        yield return new WaitForSeconds(1f);
        Pausa.noPausa = false;
        cajaAbierta.Play();
        Door.SetBool("Open", true);
        player.SetActive(true);
        camara_panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
