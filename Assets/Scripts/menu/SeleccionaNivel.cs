using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Controlador del menu de niveles
//agregamos los metodos para atender los componenetes de menu de seleccion de niveles
//Autor Diego Alejandro Juárez Ruiz

public class SeleccionaNivel : MonoBehaviour
{
    //imagen fondo
    public Image imagenfondo;
    public void Salir()
    {
        //Regresa al sistema operativo
        Application.Quit();
    }
    public void Nivel1()
    {
        //FADEOUT
        imagenfondo.canvasRenderer.SetAlpha(0);
        imagenfondo.gameObject.SetActive(true);
        imagenfondo.CrossFadeAlpha(1, 1, true);
        StartCoroutine(CambiarEscena1());
    }
    public void Nivel2()
    {
        //FADEOUT
        imagenfondo.canvasRenderer.SetAlpha(0);
        imagenfondo.gameObject.SetActive(true);
        imagenfondo.CrossFadeAlpha(1, 1, true);
        StartCoroutine(CambiarEscena2());
    }
    public void Nivel3()
    {
        //FADEOUT
        imagenfondo.canvasRenderer.SetAlpha(0);
        imagenfondo.gameObject.SetActive(true);
        imagenfondo.CrossFadeAlpha(1, 1, true);
        StartCoroutine(CambiarEscena3());
    }
    public void Nivel4()
    {
        //FADEOUT
        imagenfondo.canvasRenderer.SetAlpha(0);
        imagenfondo.gameObject.SetActive(true);
        imagenfondo.CrossFadeAlpha(1, 1, true);
        StartCoroutine(CambiarEscena4());
    }

    public void Regresar()
    {
        StartCoroutine(RegresaMenu());
    }

    private IEnumerator CambiarEscena1()
    {
        yield return new WaitForSeconds(1);
        //Ya termino los segundos
        SceneManager.LoadScene("Scenes/Nivel_I/Casa");
    }
    private IEnumerator CambiarEscena2()
    {
        yield return new WaitForSeconds(1);
        //Ya termino los segundos
        SceneManager.LoadScene("Scenes/Nivel_II/Laboratorio");
    }
    private IEnumerator CambiarEscena3()
    {
        yield return new WaitForSeconds(1);
        //Ya termino los segundos
        SceneManager.LoadScene("Scenes/Nivel_III/nivel3Pasillo");
    }
    private IEnumerator CambiarEscena4()
    {
        yield return new WaitForSeconds(1);
        //Ya termino los segundos
        SceneManager.LoadScene("Scenes/Nivel_IV/Nivel4");
    }
    private IEnumerator RegresaMenu()
    {
        yield return new WaitForSeconds(1);
        //Ya termino los segundos
        SceneManager.LoadScene("Menuprincipal");
    }
}
