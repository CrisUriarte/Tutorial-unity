using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{

    public GameObject ContenerdorCalles;
    public GameObject[] ContenedorCallesArray;

    public GameObject calleAnterior;
    public GameObject calleNueva;
    public float tamañoCalle;

    private int contadorcalle = 0;
    private int numerocalle;
    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    public Vector3 medidaPantalla;
    public bool salioDePantalla;
    public GameObject mCamGo;
    public Camera mCamComp;

    //Mecanica final del juego
    public GameObject cocheGO;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public GameObject bgFinalGO;


    // Start is called before the first frame update
    void Start()
    {
        ContenerdorCalles = GameObject.Find("ContenedorCalles");
  
        mCamGo = GameObject.Find("Main Camera");
        mCamComp = mCamGo.GetComponent<Camera>();

        cocheGO = GameObject.FindObjectOfType<Auto>().gameObject;
        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);
        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();


        MedirPantalla();
        VelocidadMotorCarretera();
        EncontrarCalles();

    }

    void EncontrarCalles()
    {
        ContenedorCallesArray = GameObject.FindGameObjectsWithTag("calle");

        for (int i = 0; i < ContenedorCallesArray.Length; i++)
        {
            ContenedorCallesArray[i].gameObject.transform.parent = ContenerdorCalles.transform;
            ContenedorCallesArray[i].gameObject.SetActive(false);
            ContenedorCallesArray[i].gameObject.name = "CalleOFF_"+i;
        }
        CrearCalles();
    }

    void CrearCalles()
    {
        contadorcalle++;
        numerocalle = Random.Range(0, ContenedorCallesArray.Length);
        GameObject Calle = Instantiate(ContenedorCallesArray[numerocalle]);
        Calle.SetActive(true);
        Calle.gameObject.name = "Calle" + contadorcalle;
        Calle.transform.parent = gameObject.transform;

        PoisionCalles();
    }

    void PoisionCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorcalle - 1));
        calleNueva = GameObject.Find("Calle" + contadorcalle);
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamañoCalle, 0);
        salioDePantalla = false;
    }

    void MidoCalle()
    {
        for(int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamañoCalle = tamañoCalle + tamañoPieza;
            }
            
        }
    }

    void MedirPantalla()
    {
        medidaPantalla = new Vector3(0, mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f, 0);
    }

    void DestruirCalle()
    {
        Destroy(calleAnterior);
        tamañoCalle = 0;
        calleAnterior = null;
 
        CrearCalles();
    }
    void VelocidadMotorCarretera()
    {
        velocidad = 18;
    }

    public void JuegoTerminadoEstados()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        audioFXScript.Musica();
        bgFinalGO.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (inicioJuego == true && juegoTerminado==false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);


            if (calleAnterior.transform.position.y + tamañoCalle < medidaPantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruirCalle();
            }
        }
        
    }

}