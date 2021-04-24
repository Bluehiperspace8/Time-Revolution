using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 Objetivo:  Reproduce el efecto de fade in en el nivel tres efecto elevador
 Autor: Roberto Valdez Jasso
 */
public class FadeInElevador : MonoBehaviour
{
    public Image imagenFondo;

    // Referencia al auido Source
    public AudioSource EfectoSonido;
    // Start is called before the first frame update
    void Start()
    {

        imagenFondo.CrossFadeAlpha(0, 4, true);
        EfectoSonido.Play();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
