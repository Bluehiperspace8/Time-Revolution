using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Manejo de instrucciones de EnergySnake
 * Diego Alejandro Ju�rez Ruiz
 * Luis Enrique Zamarripa Mar�n
 */

public class InstruccionesEnergySnake : MonoBehaviour
{
    private bool estaPausado;  // True esta en pausa si no pues esta jugando
    public GameObject pantallaPausa; //Panel que se pone oscuro

    private void Start()
    {
        Pausar();
    }

    //Cada que se solicita pausar y quitar la pausa
    public void Pausar()
    {
        estaPausado = !estaPausado; //Cambia el boolenao al valor inverso
        pantallaPausa.SetActive(estaPausado); //Poner la pantalla dependiendo del boolenao

        //Escala de tiempo
        Time.timeScale = estaPausado ? 0 : 1;
    }
}