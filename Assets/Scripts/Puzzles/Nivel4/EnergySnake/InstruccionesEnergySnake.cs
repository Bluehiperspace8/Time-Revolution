using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Manejo de instrucciones de EnergySnake
 * Diego Alejandro Juarez Ruiz
 * Luis Enrique Zamarripa Marin
 */

public class InstruccionesEnergySnake : MonoBehaviour
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
        if(estaPausado == false)
        {
            Sonido.Play();
            float tiempillo = Time.time;
            PlayerPrefs.SetFloat("inicioSnake", tiempillo);
            PlayerPrefs.Save();
        }
        //Escala de tiempo
        Time.timeScale = estaPausado ? 0 : 1;
    }
}