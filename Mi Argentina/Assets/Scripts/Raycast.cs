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

    //VARIABLES PARA PUZZLE CUADROS

        //Variables Cambio Colores Botones Cuadros

        int ColorGlaciar = 1;
        int ColorElPalmar = 1;
        int ColorCerro = 1;
        int ColorCarpincho = 1;
        int ColorPinguino = 1;
        int ColorLlama = 1;

            //GameObjects de botones
            public GameObject BotonGlaciar;
            public GameObject BotonElPalmar;
            public GameObject BotonCerro;
            public GameObject BotonCarpincho;
            public GameObject BotonPinguino;
            public GameObject BotonLlama;

            //Booleans para detectar color correcto
            bool colorGlaciarCorrecto = false;
            bool colorPalmarCorrecto = false;
            bool colorCerroCorrecto = false;
            bool colorCarpinchoCorrecto = false;
            bool colorPinguinoCorrecto = false;
            bool colorLlamaCorrecto = false;



    //VARIABLES PARA AGARRAR OBJETOS

    public Transform mano;

    public bool manoOcupada = false;
    bool agarrasteLlaveCajon = false;
    bool agarrasteLlaveArmario = false;
    bool agarrasteMate = false;

    //Sonidos
    public AudioSource agarraObjeto;
    public AudioSource sueltaObjeto;
    public AudioSource _Guitarra;
    public AudioSource armarioAbierto;
    public AudioSource armarioCerrado;
    public AudioSource llaveArmarioUnlock;
    public AudioSource botonCuadros;
    public AudioSource cuadroCataratasAbierto;
    public AudioSource cuadroCataratasCerrado;
    public AudioSource tomarMate;
    public AudioSource manija;
    public AudioSource puertaCerrada;
    public AudioSource botonMesa;

    //Camaras
    public GameObject camara_radio;
    public GameObject camara_panel;
    public GameObject camara_panel2;

    //Player
    public GameObject player;

    //BoleanoRadio
    bool radioActivada = false;

    //TextosCanvas
    public GameObject textoRadio;
    public GameObject textoPuerta;
    public GameObject textoCaja;
    public GameObject textoMate;
    public GameObject textoBoton;





    // Update is called once per frame
    void Update()
    {
        RaycastObjetosUsables();

        //Usar Llave Cajon
        UsarLlaveCajon();

        //UsarLlaveArmario
        UsarLlaveArmario();
        TimerAbriendoCerrojoArmario();

        //Puzzle Cuadros
        PuzzleCuadros();

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
                    agarraObjeto.Play();
                }

                //hit mate
                if (hit.transform.CompareTag("Mate"))
                {
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteMate = true;
                    agarraObjeto.Play();
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

    void PuzzleCuadros()
    {
        if(colorGlaciarCorrecto == true && colorPalmarCorrecto == true && colorCerroCorrecto == true && colorCarpinchoCorrecto == true
             && colorPinguinoCorrecto == true && colorLlamaCorrecto == true)
        {
            Debug.Log("RESOLVISTE EL ROMPECABEZAS");
        }
    }

    void RaycastObjetosUsables()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Hit LlaveArmario
            if (Input.GetMouseButtonDown(0) && hit.transform.CompareTag("LlaveArmario"))
            {
                    Debug.Log("ESTAS AGARRANDO LLAVE");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteLlaveArmario = true;
                    agarraObjeto.Play();
            }        

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
                    StartCoroutine("timerAudio");                  
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
                        armarioAbierto.Play();
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            aperturaPertaIzqArmario2.SetBool("Open", false);
                            aperturaPertaDerArmario2.SetBool("Open", false);
                            armario2Abierto = false;
                            armarioCerrado.Play();
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
                        cuadroCataratasAbierto.Play();
                        aperturaCuadroCataratas.SetBool("Open", true);
                        cuadroAbierto = true;
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            cuadroCataratasCerrado.Play();
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

                if(Input.GetKeyDown(KeyCode.E))
                {
                    botonCuadros.Play();
                    ColorGlaciar += 1;
                    if(ColorGlaciar == 4)
                    {
                        ColorGlaciar = 1;
                    }

                    switch (ColorGlaciar)
                    {
                        case 3:
                            BotonGlaciar.GetComponent<Renderer>().material.color = Color.red;
                            BotonGlaciar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                            BotonGlaciar.GetComponent<Light>().color = Color.red;
                            colorGlaciarCorrecto = false;
                            break;
                        case 2:
                            BotonGlaciar.GetComponent<Renderer>().material.color = Color.green;
                            BotonGlaciar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                            BotonGlaciar.GetComponent<Light>().color = Color.green;
                            colorGlaciarCorrecto = false;
                            break;
                        case 1:
                            BotonGlaciar.GetComponent<Renderer>().material.color = Color.blue;
                            BotonGlaciar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                            BotonGlaciar.GetComponent<Light>().color = Color.blue;
                            colorGlaciarCorrecto = true;
                            break;                           
                    }
                }
            }


            //BotonPalmar
            if (hit.transform.CompareTag("BotonPalmar"))
            {
                textoInteractuar.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    botonCuadros.Play();
                    ColorElPalmar  += 1;
                    if(ColorElPalmar  == 4)
                    {
                        ColorElPalmar  = 1;
                    }

                    switch (ColorElPalmar)
                    {
                        case 3:
                            BotonElPalmar.GetComponent<Renderer>().material.color = Color.red;
                            BotonElPalmar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                            BotonElPalmar.GetComponent<Light>().color = Color.red;
                            colorPalmarCorrecto = false;
                            break;
                        case 2:
                            BotonElPalmar.GetComponent<Renderer>().material.color = Color.green;
                            BotonElPalmar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                            BotonElPalmar.GetComponent<Light>().color = Color.green;
                            colorPalmarCorrecto = true;
                            break;
                        case 1:
                            BotonElPalmar.GetComponent<Renderer>().material.color = Color.blue;
                            BotonElPalmar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                            BotonElPalmar.GetComponent<Light>().color = Color.blue;
                            colorPalmarCorrecto = false;
                            break;                           
                    }
                }
            }


            //BotonCerro
            if (hit.transform.CompareTag("BotonCerro"))
            {
                textoInteractuar.SetActive(true);

                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    botonCuadros.Play();
                    ColorCerro  += 1;
                    if(ColorCerro  == 4)
                    {
                        ColorCerro  = 1;
                    }

                    switch (ColorCerro)
                    {
                        case 3:
                            BotonCerro.GetComponent<Renderer>().material.color = Color.red;
                            BotonCerro.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                            BotonCerro.GetComponent<Light>().color = Color.red;
                            colorCerroCorrecto = true;
                            break;
                        case 2:
                            BotonCerro.GetComponent<Renderer>().material.color = Color.green;
                            BotonCerro.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                            BotonCerro.GetComponent<Light>().color = Color.green;
                            colorCerroCorrecto = false;
                            break;
                        case 1:
                            BotonCerro.GetComponent<Renderer>().material.color = Color.blue;
                            BotonCerro.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                            BotonCerro.GetComponent<Light>().color = Color.blue;
                            colorCerroCorrecto = false;
                            break;                           
                    }
                }
            }


            //BotonPinguino
            if (hit.transform.CompareTag("BotonPinguino"))
            {
                textoInteractuar.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    botonCuadros.Play();
                    ColorPinguino  += 1;
                    if(ColorPinguino  == 4)
                    {
                        ColorPinguino  = 1;
                    }

                    switch (ColorPinguino)
                    {
                        case 3:
                            BotonPinguino.GetComponent<Renderer>().material.color = Color.red;
                            BotonPinguino.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                            BotonPinguino.GetComponent<Light>().color = Color.red;
                            colorPinguinoCorrecto = false;
                            break;
                        case 2:
                            BotonPinguino.GetComponent<Renderer>().material.color = Color.green;
                            BotonPinguino.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                            BotonPinguino.GetComponent<Light>().color = Color.green;
                            colorPinguinoCorrecto = false;
                            break;
                        case 1:
                            BotonPinguino.GetComponent<Renderer>().material.color = Color.blue;
                            BotonPinguino.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                            BotonPinguino.GetComponent<Light>().color = Color.blue;
                            colorPinguinoCorrecto = true;
                            break;                           
                    }
                }
            }

            //BotonCarpincho
            if (hit.transform.CompareTag("BotonCarpincho"))
            {
                textoInteractuar.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    botonCuadros.Play();
                    ColorCarpincho  += 1;
                    if(ColorCarpincho  == 4)
                    {
                        ColorCarpincho  = 1;
                    }

                    switch (ColorCarpincho)
                    {
                        case 3:
                            BotonCarpincho.GetComponent<Renderer>().material.color = Color.red;
                            BotonCarpincho.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                            BotonCarpincho.GetComponent<Light>().color = Color.red;
                            colorCarpinchoCorrecto = false;
                            break;
                        case 2:
                            BotonCarpincho.GetComponent<Renderer>().material.color = Color.green;
                            BotonCarpincho.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                            BotonCarpincho.GetComponent<Light>().color = Color.green;
                            colorCarpinchoCorrecto = true;
                            break;
                        case 1:
                            BotonCarpincho.GetComponent<Renderer>().material.color = Color.blue;
                            BotonCarpincho.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                            BotonCarpincho.GetComponent<Light>().color = Color.blue;
                            colorCarpinchoCorrecto = false;
                            break;                           
                    }
                }
            }

            //BotonLlama
            if (hit.transform.CompareTag("BotonLlama"))
            {
                textoInteractuar.SetActive(true);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    botonCuadros.Play();
                    ColorLlama  += 1;
                    if(ColorLlama  == 4)
                    {
                        ColorLlama  = 1;
                    }

                    switch (ColorLlama)
                    {
                        case 3:
                            BotonLlama.GetComponent<Renderer>().material.color = Color.red;
                            BotonLlama.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                            BotonLlama.GetComponent<Light>().color = Color.red;
                            colorLlamaCorrecto = true;
                            break;
                        case 2:
                            BotonLlama.GetComponent<Renderer>().material.color = Color.green;
                            BotonLlama.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                            BotonLlama.GetComponent<Light>().color = Color.green;
                            colorLlamaCorrecto = false;
                            break;
                        case 1:
                            BotonLlama.GetComponent<Renderer>().material.color = Color.blue;
                            BotonLlama.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                            BotonLlama.GetComponent<Light>().color = Color.blue;
                            colorLlamaCorrecto = false;
                            break;                           
                    }
                }
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

            //HitRadioConPilas
            if (hit.transform.CompareTag("Radio_Con"))
            {
                textoInteractuar.SetActive(true);
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (radioActivada == true)
                        {
                            player.SetActive(false);
                            camara_radio.SetActive(true);
                        }
                        else
                        {
                            textoRadio.SetActive(true);
                            StartCoroutine("textoOFF");
                        }
                        
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

            //HitPanel2
            if (hit.transform.CompareTag("Panel2"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        player.SetActive(false);
                        camara_panel2.SetActive(true);
                    }
                }
            }

            //HitManija
            if (hit.transform.CompareTag("Manija"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        manija.Play();
                        textoCaja.SetActive(true);
                        StartCoroutine("textoOFF");
                    }                     
                }
            }

            //HitMate
            if (hit.transform.CompareTag("Mate"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        tomarMate.Play();
                        textoMate.SetActive(true);
                        StartCoroutine("textoOFF");
                    }
                }
              
            }

            //HitPuertaSalaMusica
            if (hit.transform.CompareTag("PuertaSala"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        puertaCerrada.Play();
                        textoPuerta.SetActive(true);
                        StartCoroutine("textoOFF");
                    }
                }
            }

            //HitBotonMesa
            if (hit.transform.CompareTag("BotonMesa"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (Mate.placaMesa == true)
                        {
                            botonMesa.Play();
                            Debug.Log("Abrir Armario");
                        }
                        else
                        {
                            botonMesa.Play();
                            textoBoton.SetActive(true);
                            StartCoroutine("textoOFF");
                        }
                    }
                }
            }
        }
        else
        {
            textoInteractuar.SetActive(false);
        }       
    }

    IEnumerator timerAudio()
    {
        yield return new WaitForSeconds(2f);
        llaveArmarioUnlock.Play();
    }

    IEnumerator textoOFF()
    {
        yield return new WaitForSeconds(4f);
        textoRadio.SetActive(false);
        textoPuerta.SetActive(false);
        textoCaja.SetActive(false);
        textoMate.SetActive(false);
        textoBoton.SetActive(false);
    }
}
