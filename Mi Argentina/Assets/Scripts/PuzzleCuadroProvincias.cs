using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PuzzleCuadroProvincias : MonoBehaviour
{
    public AudioSource colocar;

    //Puerta de salida
    public Animator aperturaPuertaSalida;
    public static bool puertaSalidaAbierta = false; 
    public GameObject puertaAbriendo;

    //Variables Raycast

    public float range = 5f;
    public Camera fpsCam;

    //public LayerMask capaDelJugador;

    public float rangoDeAlerta;

    //Capa de las provincias

    public LayerMask capaDeTierraDelFuego;
    public LayerMask capaDeSantaCruz;
    public LayerMask capaDeChubut;
    public LayerMask capaDeRioNegro;
    public LayerMask capaDeNeuquen;
    public LayerMask capaDeLaPampa;
    public LayerMask capaDeBuenosAires;
    public LayerMask capaDeMendoza;
    public LayerMask capaDeSanLuis;
    public LayerMask capaDeCordoba;
    public LayerMask capaDeSantaFe;
    public LayerMask capaDeEntreRios;
    public LayerMask capaDeCorrientes;
    public LayerMask capaDeMisiones;
    public LayerMask capaDeSanJuan;
    public LayerMask capaDeLaRioja;
    public LayerMask capaDeCatamarca;
    public LayerMask capaDeTucuman;
    public LayerMask capaDeSantiagoDelEstero;
    public LayerMask capaDeChaco;
    public LayerMask capaDeFormosa;
    public LayerMask capaDeSalta;
    public LayerMask capaJujuy;

    //Booleans Detectores

    //bool detectaJugador;
    bool detectaTierraDelFuego;
    bool detectaSantaCruz;
    bool detectaChubut;
    bool detectaRioNegro;
    bool detectaNeuquen;
    bool detectaLaPampa;
    bool detectaBuenosAires;
    bool detectaMendoza;
    bool detectaSanLuis;
    bool detectaCordoba;
    bool detectaSantaFe;
    bool detectaEntreRios;
    bool detectaCorrientes;
    bool detectaMisiones;
    bool detectaSanJuan;
    bool detectaLaRioja;
    bool detectaCatamarca;
    bool detectaTucuman;
    bool detectaSantiagoDelEstero;
    bool detectaChaco;
    bool detectaFormosa;
    bool detectaSalta;
    bool detectaJujuy;

    //Objetos Provincias

    public GameObject provTDF;
    public GameObject provTDFenMano;
    public GameObject provSC;
    public GameObject provSCenMano;
    public GameObject provChu;
    public GameObject provChuEnMano;
    public GameObject provRN;
    public GameObject provRNenMano;
    public GameObject provNeu;
    public GameObject provNeuEnMano;
    public GameObject provLP;
    public GameObject provLPenMano;
    public GameObject provBA;
    public GameObject provBAenMano;
    public GameObject provMen;
    public GameObject provMenEnMano;
    public GameObject provSL;
    public GameObject provSLenMano;
    public GameObject provCord;
    public GameObject provCordEnMano;
    public GameObject provSF;
    public GameObject provSFenMano;
    public GameObject provER;
    public GameObject provERenMano;
    public GameObject provCor;
    public GameObject provCorEnMano;
    public GameObject provMis;
    public GameObject provMisEnMano;
    public GameObject provSJ;
    public GameObject provSJenMano;
    public GameObject provLR;
    public GameObject provLRenMano;
    public GameObject provCata;
    public GameObject provCataEnMano;
    public GameObject provTucu;
    public GameObject provTucuEnMano;
    public GameObject provSDE;
    public GameObject provSDEenMano;
    public GameObject provCha;
    public GameObject provChaEnMano;
    public GameObject provFor;
    public GameObject provForEnMano;
    public GameObject provSal;
    public GameObject provSalEnMano;
    public GameObject provJuj;
    public GameObject provJujEnMano;

    //Variables para comprobacion de resultado

    bool tdfColocada = false;
    bool scColocada = false;
    bool chuColocada = false;
    bool rnColocada = false;
    bool neuColocada = false;
    bool lpColocada = false;
    bool baColocada = false;
    bool menColocada = false;
    bool slColocada = false;
    bool cordColocada = false;
    bool sfColocada = false;
    bool erColocada = false;
    bool corColocada = false;
    bool misColocada = false;
    bool sjColocada = false;
    bool lrColocada = false;
    bool cataColocada = false;
    bool tucuColocada = false;
    bool sdeColocada = false;
    bool chaColocada = false;
    bool forColocada = false;
    bool salColocada = false;
    bool jujColocada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Detector();
        RaycastProvincias();
        PuzzleCuadroMapaCompletado();
    }

    void Detector()
    {
        //detectaJugador = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDelJugador);
        detectaTierraDelFuego = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeTierraDelFuego);
        detectaSantaCruz = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeSantaCruz);
        detectaChubut = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeChubut);
        detectaRioNegro = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeRioNegro);
        detectaNeuquen = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeNeuquen);
        detectaLaPampa = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeLaPampa);
        detectaBuenosAires = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeBuenosAires);
        detectaMendoza = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeMendoza);
        detectaSanLuis = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeSanLuis);
        detectaCordoba = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeCordoba);
        detectaSantaFe = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeSantaFe);
        detectaEntreRios = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeEntreRios);
        detectaCorrientes = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeCorrientes);
        detectaMisiones = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeMisiones);
        detectaSanJuan = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeSanJuan);
        detectaLaRioja = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeLaRioja);  
        detectaCatamarca = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeCatamarca); 
        detectaTucuman = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeTucuman);
        detectaSantiagoDelEstero = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeSantiagoDelEstero);
        detectaChaco = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeChaco);
        detectaFormosa = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeFormosa);
        detectaSalta = Physics.CheckSphere(transform.position,rangoDeAlerta, capaDeSalta);
        detectaJujuy = Physics.CheckSphere(transform.position,rangoDeAlerta, capaJujuy);
    }

    void RaycastProvincias()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("CuadroMapaArg"))
            {
                if(Input.GetKeyDown(KeyCode.E) && detectaTierraDelFuego == true)
                {
                    Destroy(provTDFenMano);
                    provTDF.SetActive(true);
                    tdfColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaSantaCruz == true)
                {
                    Destroy(provSCenMano);
                    provSC.SetActive(true);
                    scColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaChubut == true)
                {
                    Destroy(provChuEnMano);
                    provChu.SetActive(true);
                    chuColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaRioNegro == true)
                {
                    Destroy(provRNenMano);
                    provRN.SetActive(true);
                    rnColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaNeuquen == true)
                {
                    Destroy(provNeuEnMano);
                    provNeu.SetActive(true);
                    neuColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaLaPampa == true)
                {
                    Destroy(provLPenMano);
                    provLP.SetActive(true);
                    lpColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaBuenosAires == true)
                {
                    Destroy(provBAenMano);
                    provBA.SetActive(true);
                    baColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaMendoza == true)
                {
                    Destroy(provMenEnMano);
                    provMen.SetActive(true);
                    menColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaSanLuis == true)
                {
                    Destroy(provSLenMano);
                    provSL.SetActive(true);
                    slColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaCordoba == true)
                {
                    Destroy(provCordEnMano);
                    provCord.SetActive(true);
                    cordColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaSantaFe == true)
                {
                    Destroy(provSFenMano);
                    provSF.SetActive(true);
                    sfColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaEntreRios == true)
                {
                    Destroy(provERenMano);
                    provER.SetActive(true);
                    erColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaCorrientes == true)
                {
                    Destroy(provCorEnMano);
                    provCor.SetActive(true);
                    corColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaMisiones == true)
                {
                    Destroy(provMisEnMano);
                    provMis.SetActive(true);
                    misColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaSanJuan == true)
                {
                    Destroy(provSJenMano);
                    provSJ.SetActive(true);
                    sjColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaLaRioja == true)
                {
                    Destroy(provLRenMano);
                    provLR.SetActive(true);
                    lrColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaCatamarca == true)
                {
                    Destroy(provCataEnMano);
                    provCata.SetActive(true);
                    cataColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaTucuman == true)
                {
                    Destroy(provTucuEnMano);
                    provTucu.SetActive(true);
                    tucuColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaSantiagoDelEstero == true)
                {
                    Destroy(provSDEenMano);
                    provSDE.SetActive(true);
                    sdeColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaChaco == true)
                {
                    Destroy(provChaEnMano);
                    provCha.SetActive(true);
                    chaColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaFormosa == true)
                {
                    Destroy(provForEnMano);
                    provFor.SetActive(true);
                    forColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaSalta == true)
                {
                    Destroy(provSalEnMano);
                    provSal.SetActive(true);
                    salColocada = true;
                    colocar.Play();
                }

                if(Input.GetKeyDown(KeyCode.E) && detectaJujuy == true)
                {
                    Destroy(provJujEnMano);
                    provJuj.SetActive(true);
                    jujColocada = true;
                    colocar.Play();
                }
            }
        }

    }

    void PuzzleCuadroMapaCompletado()
    {
        if(tdfColocada == true && scColocada == true && chuColocada == true && rnColocada == true && neuColocada == true
           && lpColocada == true && baColocada == true && menColocada == true && slColocada == true && cordColocada == true
           && sfColocada == true && erColocada == true && corColocada == true && misColocada == true && sjColocada == true
           && lrColocada == true && cataColocada == true && tucuColocada == true && sdeColocada == true && chaColocada == true
           && forColocada == true && salColocada == true && jujColocada == true)
        {
            puertaSalidaAbierta = true;
            puertaAbriendo.SetActive(true);
            Debug.Log("COMPLETASTE PUZZLE FINAL");
            aperturaPuertaSalida.SetBool("Open", true);        
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
