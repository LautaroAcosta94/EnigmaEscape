using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 5f;
    public Camera fpsCam;
    public GameObject textoInteractuar;

    //Variables para apertura de Armario 2
    public Animator aperturaPertaIzqArmario2;
    public Animator aperturaPertaDerArmario2;
    bool armario2Abierto = false;

    //Hit CuadroCataratas
    public Animator aperturaCuadroCataratas;
    bool cuadroAbierto;

    //RayCast Llave
    public GameObject llave;

    //Variables para apertura de Cajon2
    public Animator aperturaCajon2;
    bool cajon2Abierto = false;

    //Variables para apertura de Armario
    public Animator aperturaArmarioLlave;

    public GameObject llaveArmario;
    public GameObject llaveArmarioEnMano;
    public GameObject candado;

    bool armarioLlaveAbierto = false;
    bool abriendoArmario = false;
    float tiempoAnimLlave = 0;


    //VARIABLES PARA AGARRAR OBJETOS

    public Transform mano;

    public bool manoOcupada = false;
    bool agarrasteLlaveCajon = false;
    bool agarrasteLlaveArmario = false;

    //Sonidos
    public AudioSource agarraObjeto;
    public AudioSource sueltaObjeto;
    public AudioSource _Guitarra;

    //Camaras
    public GameObject camara_pilas;
    public GameObject camara_radio;
    public GameObject camara_panel;

    //Player
    public GameObject player;





    // Update is called once per frame
    void Update()
    {
        RaycastObjetosUsables();

        //Usar Llave Cajon
        UsarLlaveCajon();

        //UsarLlaveArmario
        UsarLlaveArmario();
        TimerAbriendoCerrojoArmario();

        //Agarrar y Soltar Objetos
        if (Input.GetMouseButtonDown(0))
        {
            AgarrarObjeto();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (manoOcupada == true)
            {
                sueltaObjeto.Play();
                manoOcupada = false;
            }

        }
    }

    void AgarrarObjeto()
    {
        RaycastHit hit;

        if (manoOcupada == false)
        {

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                //hit provincias
                if (hit.transform.CompareTag("Provincias"))
                {
                    Debug.Log("Agarraste Provincia");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarraObjeto.Play();
                }

                //hit llave
                if (hit.transform.CompareTag("Llave"))
                {
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteLlaveCajon = true;
                }

                //hit llave Armario
                if (hit.transform.CompareTag("LlaveArmario"))
                {
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteLlaveArmario = true;
                }
            }
        }
    }

    void UsarLlaveCajon()
    {
        if (agarrasteLlaveCajon == true)
        {
            Debug.Log("Agarraste Llave");
            RaycastHit hit2;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Llave");
                agarrasteLlaveCajon = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit2, range))
            {
                if (hit2.transform.CompareTag("CajonConLlave"))
                {
                    Debug.Log("Puedes Abrir el Cajon");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (cajon2Abierto == false)
                        {
                            aperturaCajon2.SetBool("Open", true);

                            cajon2Abierto = true;
                        }
                        else
                        {
                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                aperturaCajon2.SetBool("Open", false);
                                cajon2Abierto = false;
                            }
                        }
                    }
                }
            }
        }
    }

    void UsarLlaveArmario()
    {
        if (armarioLlaveAbierto == false && agarrasteLlaveArmario == true)
        {
            Debug.Log("Agarraste Llave Armario");


            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Llave");
                agarrasteLlaveArmario = false;
            }

        }
    }

    void TimerAbriendoCerrojoArmario()
    {
        if (abriendoArmario == true)
        {
            Debug.Log("COMIENZA TIMER");
            tiempoAnimLlave += Time.deltaTime;
            if (tiempoAnimLlave >= 4)
            {
                Destroy(candado);
                Debug.Log("Armario Abierto");
                armarioLlaveAbierto = true;
                abriendoArmario = false;
                tiempoAnimLlave = 0;
            }
        }
    }

    void RaycastObjetosUsables()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Hit Armario 1
            if (hit.transform.CompareTag("PuertaArmario1"))
            {
                textoInteractuar.SetActive(true);
            }
            else
            {
                textoInteractuar.SetActive(false);
            }

            //Hit Armario 2
            if (hit.transform.CompareTag("PuertaArmario2") && agarrasteLlaveArmario == true)
            {
                textoInteractuar.SetActive(true);
                //Abrir Puerta Armario

                Debug.Log("Puedes Abrir el armario");
                if (armarioLlaveAbierto == false && Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(llaveArmarioEnMano);
                    Debug.Log("ESTAS ABRIENDO ARMARIO");
                    llaveArmario.SetActive(true);
                    aperturaArmarioLlave.SetBool("Open", true); //AQUI 
                    abriendoArmario = true;
                }
            }

            //HIT ARMARIO 2 Abierto
            if (hit.transform.CompareTag("PuertaArmario2") && armarioLlaveAbierto == true)
            {
                textoInteractuar.SetActive(true);
                Debug.Log("ESTAS VIENDO EL ARMARIO ABIERTO");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (armario2Abierto == false)
                    {
                        aperturaPertaIzqArmario2.SetBool("Open", true);
                        aperturaPertaDerArmario2.SetBool("Open", true);

                        armario2Abierto = true;
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            aperturaPertaIzqArmario2.SetBool("Open", false);
                            aperturaPertaDerArmario2.SetBool("Open", false);
                            armario2Abierto = false;
                        }
                    }
                }
            }

            //Hit CuadroCataratas
            if (hit.transform.CompareTag("CuadroCataratas"))
            {
                textoInteractuar.SetActive(true);

                //Abrir Cuadro
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (cuadroAbierto == false)
                    {
                        aperturaCuadroCataratas.SetBool("Open", true);
                        cuadroAbierto = true;
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            aperturaCuadroCataratas.SetBool("Open", false);
                            cuadroAbierto = false;
                        }
                    }
                }
            }

            //Hit Cajon Con Llave
            if (hit.transform.CompareTag("CajonConLlave"))
            {
                textoInteractuar.SetActive(true);
            }

            //Hit CuadroMapaArg
            if (hit.transform.CompareTag("CuadroMapaArg"))
            {
                textoInteractuar.SetActive(true);

            }


            //Hit CuadroMapaArg
            if (hit.transform.CompareTag("CuadroMapaArg"))
            {
                textoInteractuar.SetActive(true);
            }

            //Hit BotonesCuadros

            //BotonGlaciar
            if (hit.transform.CompareTag("BotonGlaciar"))
            {
                textoInteractuar.SetActive(true);
            }


            //BotonPalmar
            if (hit.transform.CompareTag("BotonPalmar"))
            {
                textoInteractuar.SetActive(true);
            }


            //BotonCerro
            if (hit.transform.CompareTag("BotonCerro"))
            {
                textoInteractuar.SetActive(true);
            }


            //BotonPinguino
            if (hit.transform.CompareTag("BotonPinguino"))
            {
                textoInteractuar.SetActive(true);
            }

            //BotonCarpincho
            if (hit.transform.CompareTag("BotonCarpincho"))
            {
                textoInteractuar.SetActive(true);
            }

            //BotonLlama
            if (hit.transform.CompareTag("BotonLlama"))
            {
                textoInteractuar.SetActive(true);
            }

            //HitTV
            if (hit.transform.CompareTag("TV"))
            {
                textoInteractuar.SetActive(true);
            }

            //HitGuitarra
            if (hit.transform.CompareTag("Guitarra"))
            {
                textoInteractuar.SetActive(true);
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        _Guitarra.Play();
                    }

                }
            }
            //HitRadioSinPilas
            if (hit.transform.CompareTag("Radio_Sin"))
            {
                textoInteractuar.SetActive(true);
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        player.SetActive(false);
                        camara_pilas.SetActive(true);
                    }

                }
            }
            //HitRadioConPilas
            if (hit.transform.CompareTag("Radio_Con"))
            {
                textoInteractuar.SetActive(true);
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        player.SetActive(false);
                        camara_radio.SetActive(true);
                    }

                }
            }
            //HitPiano
            if (hit.transform.CompareTag("Piano"))
            {
                textoInteractuar.SetActive(true);
            }
            //HitPanel
            if (hit.transform.CompareTag("Panel"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        player.SetActive(false);
                        camara_panel.SetActive(true);
                    }
                }
            }
        }
        else
        {
            textoInteractuar.SetActive(false);
        }       
    }
}
