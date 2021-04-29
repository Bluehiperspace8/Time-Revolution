using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Objetivo: el diálogo con Jacob en el laboratorio
 * Autor: Renata de la Luna
 * Autor: Diego Alejandro Juarez Ruiz
 * Autor: Luis Enrique Zamarripa
 * Referencia a: Drosgame
 * Youtube: https://youtu.be/FjoL4ufZmXc
 */

public class Dialogo3Martin : MonoBehaviour
{
    // Variables ---//
    // llamanndo al mensaje
    public TextMeshProUGUI textD;

    [TextArea(3, 30)]
    // String para el Texto (Arreay de Parrafos)
    public string[] parrafos;

    // Index
    int index;

    //Velocidad del Parrafo
    public float velParrafo;

    // GameObjects----//
    // Botones
    // Boton Continuar 
    public GameObject botonContinuar;

    // Boton Quitar
    public GameObject botonQuitar;

    // Panel Dialogo
    public GameObject PanelDialogo;

    // Boton Lectura
    public GameObject BotonLeer;

    // Boton Saltar
    public GameObject botonSaltar;

    // Referencia al auido Source
    public AudioSource EfectoSonido;

    // Game Object Objecto necesario para el Puzzle
    public GameObject plataforma1;
    public GameObject plataforma2;



    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        botonQuitar.SetActive(false);
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        plataforma1.SetActive(false);
        plataforma2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Si utilizamos el objecto pasamos al if

        if (textD.text == parrafos[index])
        {
            botonSaltar.SetActive(true);
            botonContinuar.SetActive(true);
        }
    }

    // Corutina

    IEnumerator TextDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {

            textD.text += letra;

            yield return new WaitForSeconds(velParrafo);
        }
    }

    // Funcion
    // Manejo de los controles
    public void siguienteParrafo()
    {
        botonSaltar.SetActive(false);
        botonContinuar.SetActive(false);
        if (index < parrafos.Length - 1)
        {
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        }
        else
        {
            //última línea del diálogo
            textD.text = "¡¡¡Buena suerte!!!";
            botonContinuar.SetActive(false);
            botonQuitar.SetActive(true);

        }
    }

    //Interaccion  con el jugador
    public void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.CompareTag("Player"))
        {
            //Cuando entra en otro collider, se activa el botón para iniciar la conversación
            BotonLeer.SetActive(true);

        }
        else
        {
            BotonLeer.SetActive(false);

        }
    }

    public void OnTriggerExit2D(Collider2D collsion)
    {
        if (collsion.CompareTag("Player"))
        {
            BotonLeer.SetActive(false);
            PisoPrueba.estaenpiso = true;
        }
    }

    public void activarBotonLeer()
    {
        //Comienza la conversación, se activa el panel y el sonido
        PanelDialogo.SetActive(true);
        EfectoSonido.Play();
        StartCoroutine(TextDialogo());
    }

    public void botonCerrar()
    {
        //Se desactivan los botones y el panel de la conversación
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        botonQuitar.SetActive(false);

        // Activando plataforma
        plataforma1.SetActive(true);
        plataforma2.SetActive(true);
        textD.text = "";
        Destroy(gameObject, t: 0.1f);
    }

    public void BotonSaltar()
    {
        botonCerrar();
        botonContinuar.SetActive(false);
        botonSaltar.SetActive(false);
    }
}

