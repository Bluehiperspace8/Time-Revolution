using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Manejo de instrucciones de CoreDrop
 * Diego Alejandro Juárez Ruiz
 * Luis Enrique Zamarripa Marín
 */

public class InstruccionesCoreDrop : MonoBehaviour
{
    private bool estaPausado;  // True esta en pausa si no pues esta jugando
    public GameObject pantallaPausa; //Panel que se pone oscuro
    public AudioSource Sonido;

    private void Start()
    {
        Pausar();
    }

    //Cada que se solicita pausar y quitar la pausa
    public void Pausar()
    {
        estaPausado = !estaPausado; //Cambia el boolenao al valor inverso
        pantallaPausa.SetActive(estaPausado); //Poner la pantalla dependiendo del boolenao
        if (estaPausado == false)
        {
            Sonido.Play();
            float tiempo = Time.time;
            PlayerPrefs.SetFloat("inicioCoreDrop", tiempo);
        }
        //Escala de tiempo
        Time.timeScale = estaPausado ? 0 : 1;
    }
}

