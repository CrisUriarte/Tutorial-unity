using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAuto : MonoBehaviour
{
    public GameObject auto;

    public float anguloGiro = 40;
    public float velocidadLados = 20;
    public float velocidad = 10;

    // Start is called before the first frame update
    void Start()
    {
        auto = GameObject.FindObjectOfType<Auto>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        float GiroZ = 0; 
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidadLados * Time.deltaTime);
        transform.Translate(Vector2.up * Input.GetAxis("Vertical") * velocidad * Time.deltaTime);

        GiroZ = Input.GetAxis("Horizontal") * -anguloGiro;
        auto.transform.rotation = Quaternion.Euler(0, 0, GiroZ);

    }
}