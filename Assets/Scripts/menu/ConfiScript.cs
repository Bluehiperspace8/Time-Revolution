using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * Configuraciones del juego, para mover el tiempo del jugador y el sonido
 * Autor: Diego Alejandro Juárez Ruiz
 * Luis Enrique Zamarripa
 */

public class ConfiScript : MonoBehaviour
{
    public Slider tiempo;  //Slider de tiempo de animación
    public Slider sonido;  //Slider de sonido
    // Start is called before the first frame update
    public static ConfiScript instance;

    public void cambiaTiempo()
    {
        float valor = tiempo.value;
        Time.timeScale = valor;
    }

    public void cambiaSonido()
    {
        float valor = sonido.value;
        sonido.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void Regresa()
    {
        SceneManager.LoadScene("Menuprincipal");
    }
}
