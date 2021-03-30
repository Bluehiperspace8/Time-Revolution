using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Código que controla el Menu Principal
 * Diego Alejandro Juárez Ruiz 
 * Luis Enrique el zama
 * Robert
 * Renata
 * Melissa
 */

public class menu : MonoBehaviour
{
   public void Salir()
    {
        Application.Quit();
    }
    public void IniciarJuego()
    {
        SceneManager.LoadScene("nivel1");
    }
    /*
    public void AprendeSteam()
    {
        SceneManager.LoadScene("Aprendiendo");
    }
    public void Configuracion()
    {
        SceneManager.LoadScene("Configuraciones");
    }
    */
}
