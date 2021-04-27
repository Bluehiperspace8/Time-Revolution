using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * C�digo que controla el Menu Principal
 * Diego Alejandro Ju�rez Ruiz 
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