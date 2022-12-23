using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad_2 : MonoBehaviour
{
    [SerializeField] public Text Ans;
    [SerializeField] public Animator Door;
    public string Answer = "1234";

    public GameObject camara_panel2;
    public GameObject player;
    public BoxCollider panel2;
    public BoxCollider puertaSala;

    public AudioSource puertaAbierta;
    public AudioSource codigoCorrecto;
    public AudioSource codigoIncorrecto;

    public GameObject textoPuerta;

    void Update()
    {
        textoPuerta.SetActive(false); 
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
            panel2.enabled = false;
            puertaSala.enabled = false;
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
        puertaAbierta.Play();
        Door.SetBool("Open", true);
        player.SetActive(true);
        camara_panel2.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
