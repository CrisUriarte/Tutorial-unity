using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    public GameObject motorCarretera;
    public MotorCarreteras scriptMotorCarretera;

    private float tiempo = 30;
    private float distancia;
    
   

    public Text txtTiempo;
    public Text txtDistancia;



    // Start is called before the first frame update
    void Start()
    {
        motorCarretera = GameObject.Find("MotorCarretera");
        scriptMotorCarretera = motorCarretera.GetComponent<MotorCarreteras>();

        txtTiempo.text = "2:00";
        txtDistancia.text = "0";


    }

    // Update is called once per frame
    void Update()
    {
        
        if (scriptMotorCarretera.inicioJuego == true && scriptMotorCarretera.juegoTerminado == false)
        {
            CalculoTiempoDistancia();
            
        }
        if(tiempo <= 0 && scriptMotorCarretera.juegoTerminado == false)
        {
            scriptMotorCarretera.juegoTerminado = true;
        }
        
    }

    void CalculoTiempoDistancia()
    {
        distancia += Time.deltaTime * scriptMotorCarretera.velocidad;
        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;

        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2,'0');


    }

 
  
}
