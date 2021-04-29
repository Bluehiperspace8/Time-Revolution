using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/*
 * Objetivo: Dialogo al ver la gran pantalla de cristal en el futuro
 * Autor: Renata de la Luna
 * Autor: Diego Alejandro Juarez Ruiz
 * Autor: Luis Enrique Zamarripa
 * Referencia a: Drosgame
 * Youtube: https://youtu.be/FjoL4ufZmXc
 */

public class Dialogo1Martin : MonoBehaviour
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

    // Game Object Matines
    public GameObject martin1;
    public GameObject martin2;

    //Imagen Fondo
    public Image imagenFondo;


    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        botonQuitar.SetActive(false);
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        martin2.SetActive(false);
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
            //Continúa el diálogo
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        }
        else
        {
            //Última línea del diálogo
            textD.text = "¿Quieres que te traiga algo?";
            botonContinuar.SetActive(false);
            botonQuitar.SetActive(true);

        }
    }

    //Interaccion  con el jugador
    public void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.CompareTag("Player"))
        {
            BotonLeer.SetActive(true);
            float tiempo = Time.time;
            PlayerPrefs.SetFloat("tiemponivel2", tiempo);

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
        PanelDialogo.SetActive(true);
        EfectoSonido.Play();
        StartCoroutine(TextDialogo());
    }

    public void botonCerrar()
    {
        //Desactivar panel y botones
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        botonQuitar.SetActive(false);
        textD.text = "";

        //Efecto fade out
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1, 3, true);
        //Desactivamos al primer Martin para que ya no esté en la escena
        martin1.SetActive(false);
        new WaitForSeconds(3);

        //Activamos al segundo Martin
        martin2.SetActive(true);
        //Efecto de fade in para volver a la escena
        StartCoroutine(EfectoDadeIn());
        

    }

    public IEnumerator EfectoDadeIn()
    {
        //Efecto de fade in
        yield return new WaitForSeconds(3);
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(false);
        imagenFondo.CrossFadeAlpha(0, 6, true);
        Destroy(gameObject, t: 0.1f);
    }

    public void BotonSaltar()
    {
        botonCerrar();
        botonContinuar.SetActive(false);
        botonSaltar.SetActive(false);
    }
}
