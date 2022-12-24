using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 5f;
    public Camera fpsCam;
    public GameObject textoInteractuar;



    //Radio y pilas

    bool pilasEnMano = false;
    public GameObject pilasMano;
    public GameObject pilasRadio;

    //Variables para apertura de Armario 2
    public Animator aperturaPertaIzqArmario2;
    public Animator aperturaPertaDerArmario2;
    bool armario2Abierto = false;

    //Hit CuadroCataratas
    public Animator aperturaCuadroCataratas;
    bool cuadroAbierto;

    //RayCast Llave
    public GameObject llave;

    //Variables para apertura de Armario
    public Animator aperturaArmarioLlave;

    public GameObject llaveArmario;
    public GameObject llaveArmarioEnMano;
    public GameObject candado;

    bool armarioLlaveAbierto = false;
    bool abriendoArmario = false;
    float tiempoAnimLlave = 0;

    //GameObjects Puzzle Escudo Nacional 
    public GameObject ovaloEscudoEnMano;
    public GameObject ovaloEscudo;
    public GameObject picaEscudoEnMano;
    public GameObject picaEscudo;
    public GameObject gorroEscudoEnMano;
    public GameObject gorroEscudo;
    public GameObject manosEscudoEnMano;
    public GameObject manosEscudo;
    public GameObject laurelesEscudoEnMano;
    public GameObject laurelesEscudo;
    public GameObject solEscudoEnMano;
    public GameObject solEscudo;

    //Animators mueble dormitorio
    public Animator aperturaPertaIzqMueble;
    public Animator aperturaPertaDerMueble;

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
    bool agarrasteOvaloEscudo = false;
    bool agarrastePicaEscudo = false;
    bool agarrasteGorroEscudo = false;
    bool agarrasteManosEscudo = false;
    bool agarrasteLaurelesEscudo = false;
    bool agarrasteSolEscudo = false;

    //bools para detectar piezas colocadas escudo
    bool ovaloEscudoColocado = false;
    bool picaEscudoColocado = false;
    bool gorroEscudoColocado = false;
    bool manosEscudoColocado = false;
    bool laurelesEscudoColocado = false;
    bool solEscudoColocado = false;

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
    public AudioSource pistaNotas;
    public AudioSource armarioDormitorio;
    public AudioSource colocarObjeto;


    //Camaras
    public GameObject camara_radio;
    public GameObject camara_panel;
    public GameObject camara_panel2;
    public GameObject camara_pista1;
    public GameObject camara_pista2;
    public GameObject camara_pista3;

    //Player
    public GameObject player;

    //Boleanos
    bool radioActivada = false;
    bool armarioAbiertoBoton = false;

    //TextosCanvas
    public GameObject textoRadio;
    public GameObject textoPuerta;
    public GameObject textoCaja;
    public GameObject textoMate;
    public GameObject textoBoton;
    public GameObject textoCajon;

    //Animator
    public Animator armarioCuadros;
    public Animator cofre;

    //GameObjects
    public GameObject cofreActivo;

    //BoxColliders
    public BoxCollider cerraduraCajon;
    public BoxCollider cajon2;

    //Llave dormitorio
    public GameObject textoAgarrar;
    public GameObject llaveDormitorioEnMano;
    bool agarrasteLlaveDormitorio = false;
    bool abristePuertaDormitorio = false;
    bool sonoPuertaDormitorio = false;
    public Animator aperturaPuertaDormitorio;
    public AudioSource puertaAbriendo;

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        RaycastObjetosUsables();

        //puzzle escudo Nacional
        UsarOvaloEscudo();
        UsarPicaEscudo();
        UsarGorroEscudo();
        UsarManosEscudo();
        UsarLaurelesEscudo();
        UsarSolEscudo();
        PuzzleCuadroEscudo();

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
                //hit LlaveDormitorio y uso

                if (hit.transform.CompareTag("LlaveArmario"))
                {
                        textoAgarrar.SetActive(true);
                        if(Input.GetMouseButtonDown(0))
                        {
                        Debug.Log("ESTAS AGARRANDO LLAVE");
                        hit.transform.SetParent(mano);
                        hit.transform.position = mano.position; //Mano = Spawn
                        //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                        manoOcupada = true;
                        agarrasteLlaveArmario = true;
                        agarraObjeto.Play();
                        }
                }

                //hit provincias
                if (hit.transform.CompareTag("Provincias"))
                {
                    textoAgarrar.SetActive(true);
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
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteLlaveCajon = true;
                    agarraObjeto.Play();
                }

                //hit ovalo escudo

                if(hit.transform.CompareTag("OvaloEscudoNacional"))
                {
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position;
                    manoOcupada = true;
                    agarrasteOvaloEscudo  = true;
                    agarraObjeto.Play();
                }

                //hit pica 

                if(hit.transform.CompareTag("PicaEscudoNacional"))
                {
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position;
                    manoOcupada = true;
                    agarrastePicaEscudo  = true;
                    agarraObjeto.Play();
                }

                //hit gorro frijio

                if(hit.transform.CompareTag("GorroEscudoNacional"))
                {
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position;
                    manoOcupada = true;
                    agarrasteGorroEscudo  = true;
                    agarraObjeto.Play();
                }

                //hit manos escudo

                if(hit.transform.CompareTag("ManosEscudoNacional"))
                {
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position;
                    manoOcupada = true;
                    agarrasteManosEscudo  = true;
                    agarraObjeto.Play();
                }

                //hit laureles escudo

                if(hit.transform.CompareTag("LaurelesEscudoNacional"))
                {
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position;
                    manoOcupada = true;
                    agarrasteLaurelesEscudo  = true;
                    agarraObjeto.Play();
                }

                //hit sol escudo

                if(hit.transform.CompareTag("SolEscudoNacional"))
                {
                    textoAgarrar.SetActive(true);
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position;
                    manoOcupada = true;
                    agarrasteSolEscudo  = true;
                    agarraObjeto.Play();
                }

                //hit mate
                if (hit.transform.CompareTag("Mate"))
                {
                    textoAgarrar.SetActive(true);
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

    void UsarOvaloEscudo()
    {
        if (agarrasteOvaloEscudo == true)
        {
            Debug.Log("Agarraste Ovalo Escudo");
            RaycastHit hitOvalo;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Ovalo Escudo");
                agarrasteOvaloEscudo = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitOvalo, range))
            {
                if (hitOvalo.transform.CompareTag("CuadroEscudoNacional"))
                {
                    Debug.Log("Puedes Colocar Objeto");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (ovaloEscudoColocado == false)
                        {
                          Destroy(ovaloEscudoEnMano);
                          ovaloEscudo.SetActive(true);
                          ovaloEscudoColocado = true;
                        }

                    }
                }
            }
        }
    }

    void UsarPicaEscudo()
    {
        if (agarrastePicaEscudo == true)
        {
            Debug.Log("Agarraste Pica Escudo");
            RaycastHit hitPica;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Pica Escudo");
                agarrastePicaEscudo = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitPica, range))
            {
                if (hitPica.transform.CompareTag("CuadroEscudoNacional"))
                {
                    Debug.Log("Puedes Colocar Objeto");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (picaEscudoColocado == false)
                        {
                          Destroy(picaEscudoEnMano);
                          picaEscudo.SetActive(true);
                          picaEscudoColocado = true;
                        }

                    }
                }
            }
        }
    }

    void UsarGorroEscudo()
    {
        if (agarrasteGorroEscudo == true)
        {
            Debug.Log("Agarraste Gorro Escudo");
            RaycastHit hitGorro;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Gorro Escudo");
                agarrasteGorroEscudo = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitGorro, range))
            {
                if (hitGorro.transform.CompareTag("CuadroEscudoNacional"))
                {
                    Debug.Log("Puedes Colocar Objeto");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (gorroEscudoColocado == false)
                        {
                          Destroy(gorroEscudoEnMano);
                          gorroEscudo.SetActive(true);
                          gorroEscudoColocado = true;
                        }

                    }
                }
            }
        }
    }

    void UsarManosEscudo()
    {
        if (agarrasteManosEscudo == true)
        {
            Debug.Log("Agarraste Manos Escudo");
            RaycastHit hitManos;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Manos Escudo");
                agarrasteManosEscudo = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitManos, range))
            {
                if (hitManos.transform.CompareTag("CuadroEscudoNacional"))
                {
                    Debug.Log("Puedes Colocar Objeto");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (manosEscudoColocado == false)
                        {
                          Destroy(manosEscudoEnMano);
                          manosEscudo.SetActive(true);
                          manosEscudoColocado = true;
                        }

                    }
                }
            }
        }
    }

    void UsarLaurelesEscudo()
    {
        if (agarrasteLaurelesEscudo == true)
        {
            Debug.Log("Agarraste Laureles Escudo");
            RaycastHit hitLaureles;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Laureles Escudo");
                agarrasteLaurelesEscudo = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitLaureles, range))
            {
                if (hitLaureles.transform.CompareTag("CuadroEscudoNacional"))
                {
                    Debug.Log("Puedes Colocar Objeto");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (laurelesEscudoColocado == false)
                        {
                          Destroy(laurelesEscudoEnMano);
                          laurelesEscudo.SetActive(true);
                          laurelesEscudoColocado = true;
                        }

                    }
                }
            }
        }
    }

    void UsarSolEscudo()
    {
        if (agarrasteSolEscudo == true)
        {
            Debug.Log("Agarraste Sol Escudo");
            RaycastHit hitSol;

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Sol Escudo");
                agarrasteSolEscudo = false;
            }

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitSol, range))
            {
                if (hitSol.transform.CompareTag("CuadroEscudoNacional"))
                {
                    Debug.Log("Puedes Colocar Objeto");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (solEscudoColocado == false)
                        {
                          Destroy(solEscudoEnMano);
                          solEscudo.SetActive(true);
                          solEscudoColocado = true;
                        }

                    }
                }
            }
        }
    }

    void PuzzleCuadroEscudo()
    {
        if(ovaloEscudoColocado == true && picaEscudoColocado == true && gorroEscudoColocado == true && 
            manosEscudoColocado == true && laurelesEscudoColocado == true && solEscudoColocado == true)
            {
                Debug.Log("PUZZLE ESCUDO RESUELTO");
                aperturaPertaIzqMueble.SetBool("Open", true);
                aperturaPertaDerMueble.SetBool("Open", true);              
            }
    }

    void UsarLlaveCajon()
    {
        if (agarrasteLlaveCajon == true)
        {
            Debug.Log("Agarraste Llave");
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Llave");
                agarrasteLlaveCajon = false;
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

    void UsarLlaveDormitorio()
    {
        if (abristePuertaDormitorio == false && agarrasteLlaveDormitorio == true)
        {
            Debug.Log("Agarraste Llave Armario");


            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Soltaste Llave");
                agarrasteLlaveDormitorio = false; //ACAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
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
            cofre.SetBool("Open", true);
            cofreActivo.SetActive(true);
        }
    }

    void RaycastObjetosUsables()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {


            //Hit LlaveDormitorio
            if (hit.transform.CompareTag("LlaveDormitorio"))
            {
                    textoAgarrar.SetActive(true);
                    if(Input.GetMouseButtonDown(0))
                    {
                    Debug.Log("ESTAS AGARRANDO LLAVE DORMITORIO");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);
                    manoOcupada = true;
                    agarrasteLlaveDormitorio = true;
                    agarraObjeto.Play();
                    }
            }   

            if(agarrasteLlaveDormitorio == true && hit.transform.CompareTag("PuertaDormitorio"))
            {
                textoInteractuar.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(llaveDormitorioEnMano);
                    aperturaPuertaDormitorio.SetBool("Open", true);
                    abristePuertaDormitorio = true;
                    if(sonoPuertaDormitorio == false && abristePuertaDormitorio == true)
                    {
                        puertaAbriendo.Play();
                        sonoPuertaDormitorio = true;
                    }
                }

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

            //Hit Cajones
            if (hit.transform.CompareTag("Cajones"))
            {
                textoInteractuar.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<AperturaCajones>().AbreCierra();
                }
            }

            //Hit Cajon Con Llave
            if (hit.transform.CompareTag("CajonConLlave"))
            {
                textoInteractuar.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (agarrasteLlaveCajon == true)
                    {
                        llaveArmarioUnlock.Play();
                        cerraduraCajon.enabled = false;
                        cajon2.enabled = true;
                        Destroy(llave);
                    }
                    else
                    {
                        textoCajon.SetActive(true);
                        StartCoroutine("textoOFF");
                        puertaCerrada.Play();
                    }
                }     
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

            //hit pilas 

            if(hit.transform.CompareTag("Pilas"))
            {
                textoAgarrar.SetActive(true);

                if(Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Agarraste Pilas");
                    hit.transform.SetParent(mano);
                    hit.transform.position = mano.position; //Mano = Spawn
                    //hit.transform.localScale = new Vector3(0.14782f, 0.14782f, 0.14782f);                    
                    manoOcupada = true;
                    agarraObjeto.Play();
                    pilasEnMano = true;
                }
            }

            //HitRadioConPilas
            if (hit.transform.CompareTag("Radio_Con"))
            {
                textoInteractuar.SetActive(true);

                if(pilasEnMano == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        colocarObjeto.Play();
                        Destroy(pilasMano);
                        pilasRadio.SetActive(true);
                        radioActivada = true;
                    }
                }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (radioActivada == true)
                        {
                            player.SetActive(false);
                            camara_radio.SetActive(true);
                            Pausa.noPausa = true;
                        }
                        else
                        {
                            textoRadio.SetActive(true);
                            StartCoroutine("textoOFF");
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
                        Pausa.noPausa = true;
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
                        Pausa.noPausa = true;
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

            //HitCopa
            if (hit.transform.CompareTag("Copa"))
            {
                textoInteractuar.SetActive(true);
            }

            //Hit puerta salida
            if (hit.transform.CompareTag("PuertaDeSalida"))
            {
                textoInteractuar.SetActive(true);
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

            //HitPista1
            if (hit.transform.CompareTag("Pista1"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pistaNotas.Play();
                        camara_pista1.SetActive(true);
                        player.SetActive(false);
                        Pausa.noPausa = true;
                    }
                }
            }

            //HitPista2
            if (hit.transform.CompareTag("Pista2"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pistaNotas.Play();
                        camara_pista2.SetActive(true);
                        player.SetActive(false);
                        Pausa.noPausa = true;
                    }
                }
            }

            //HitPista3
            if (hit.transform.CompareTag("Pista3"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pistaNotas.Play();
                        camara_pista3.SetActive(true);
                        player.SetActive(false);
                        Pausa.noPausa = true;
                    }
                }
            }

            //HitBotonMesa
            if (hit.transform.CompareTag("BotonMesa"))
            {
                textoInteractuar.SetActive(true);
                {
                    if (Input.GetKeyDown(KeyCode.E) && armarioAbiertoBoton == false)
                    {
                        if (Mate.placaMesa == true)
                        {
                            botonMesa.Play();
                            armarioCuadros.SetBool("Open", true);
                            armarioAbiertoBoton = true;
                            armarioAbierto.Play();
                        }
                        else
                        {
                            botonMesa.Play();
                            textoBoton.SetActive(true);
                            StartCoroutine("textoOFF");
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && armarioAbiertoBoton == true)
                    {
                        botonMesa.Play();
                    }
                }
            }
        }
        else
        {
            textoInteractuar.SetActive(false);
            textoAgarrar.SetActive(false);
        }       
    }


    IEnumerator timerAudio()
    {
        yield return new WaitForSeconds(2f);
        llaveArmarioUnlock.Play();
    }

    IEnumerator textoOFF()
    {
        yield return new WaitForSeconds(2.5f);
        textoRadio.SetActive(false);
        textoPuerta.SetActive(false);
        textoCaja.SetActive(false);
        textoMate.SetActive(false);
        textoBoton.SetActive(false);
        textoCajon.SetActive(false);
    }
}
