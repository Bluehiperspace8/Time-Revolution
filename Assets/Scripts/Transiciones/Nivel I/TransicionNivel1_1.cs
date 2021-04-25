using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 Objetivo: Pasar a la transicion del  Casa y Nivel I del Prota
 Autor: Roberto Valdez Jasso
 */

public class TransicionNivel1_1 : MonoBehaviour
{
    // Variables ---//
    // llamanndo al mensaje
    public TextMeshProUGUI textD;


    //Velocidad del Parrafo
    public float velParrafo;

    // GameObjects----//
    // Botones
    // Boton Si 
    public GameObject botonSi;


    // Boton Boton No
    public GameObject botonNo;

    // Panel Dialogo
    public GameObject PanelDialogo;
    // Boton Lectura
    public GameObject BotonLeer;


    // Referencia al auido Source
    public AudioSource EfectoSonido;

    //Imagen que dara la transicion en negro a la siguiente escena
    public Image imagenFondo;

    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        //imagenFondo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Si utilizamos el objecto pasamos al if

    }




    //Interaccion  con el jugador
    public void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.CompareTag("Player"))
        {
            BotonLeer.SetActive(true);

        }
        else
        {
            BotonLeer.SetActive(false);

        }
    }
    //Activaar la pregunta
    public void activarBotonLeer()
    {

        PanelDialogo.SetActive(true);
        textD.text = "Listo para seguir adelante:";
        
        botonSi.SetActive(true);
        botonNo.SetActive(true);



    }
   
    //Cambiar de mapa
    public void botoncambiar()
    {
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        //Reproducimos el sonido
        EfectoSonido.Play();

        // Esperamos Tres segundos y esperamos que efecto Fade in aparezca
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1,0.8f, true);
        new WaitForSeconds(3);
        botonSi.SetActive(false);
        botonNo.SetActive(false);

        // Cargamos Escena
        StartCoroutine(CambiarEscena());

        // destruimos el Objeto
        //Destroy(gameObject, t: 0.1f);
    }

    //Corrutina -> Cambio de escena
    private IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(0.8f);
        // Cambiar de escena
        //Ya regreso /Ya termino
        SceneManager.LoadScene("Scenes/Nivel_I/nivel1");
    }


    public void botonQuedarse()
    {
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        
    }
}
