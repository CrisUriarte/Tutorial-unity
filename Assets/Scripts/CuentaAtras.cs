using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCarretera;
    public MotorCarreteras scripMotorCarreteras;
    public Sprite[] numeros;

    public GameObject contadorNumeros;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorAuto;
    public GameObject auto;
    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();
    }

    void InicioComponentes()
    {
        motorCarretera = GameObject.Find("MotorCarretera");
        scripMotorCarreteras = motorCarretera.GetComponent<MotorCarreteras>();

        contadorNumeros = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumeros.GetComponent<SpriteRenderer>();

        controladorAuto = GameObject.Find("ControladorAuto");
        auto = GameObject.Find("Auto");

        FuncionCuentaAtras();
        
    }

    void FuncionCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        controladorAuto.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        scripMotorCarreteras.inicioJuego = true;
        contadorNumeros.GetComponent<AudioSource>().Play();
        auto.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumeros.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
