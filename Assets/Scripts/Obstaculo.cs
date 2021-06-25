using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{

    public GameObject sonidos;
    public AudioFX scriptSonido;
    public GameObject tiempo;
    public Cronometro scriptCronometro;
    
    
    void Start()
    {
        sonidos = GameObject.FindObjectOfType<AudioFX>().gameObject;
        scriptSonido = sonidos.GetComponent<AudioFX>();

        tiempo = GameObject.FindObjectOfType<Cronometro>().gameObject;
        scriptCronometro = tiempo.GetComponent<Cronometro>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.GetComponent<Auto>() != null)
        {

            Destroy(this.gameObject);
            scriptSonido.SonidoChoque();
            scriptCronometro.tiempo = scriptCronometro.tiempo - 10;

        }
    }

}