using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Código que controla el Menu Principal
 * Diego Alejandro Juárez Ruiz 
 * Luis Enrique Zamarripa
 */

public class Menu1 : MonoBehaviour
{

    public void Salir()
    {
        Application.Quit();
    }
    public void IniciarJuego()
    {
        SceneManager.LoadScene("EleccionMenu");
    }
    public void Configuracion()
    {
        SceneManager.LoadScene("Configuraciones");
    }
}