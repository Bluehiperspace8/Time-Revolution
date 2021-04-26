using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
Ultima platica de Amelie en el pasillo Nivel II
 Autor: Roberto Valdez Jasso
 */


public class TransicionFinalPasillo : MonoBehaviour
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



    // PANEL MISION CUMPLIDA
    public GameObject PanelMisionCumplida;

    // Boton Seguir al Siguiente Nivel

    public GameObject BotonNivel;
    public GameObject BotonMenu;

    // Referencia al auido Source1(Dialogo)
    public AudioSource EfectoSonido;


    // Referencia al auido Source (Elevador pasando al siguiente nivel)
    public AudioSource EfectoSonido2;

    //Imagen que dara la transicion en negro a la siguiente escena
    public Image imagenFondo;

    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        botonQuitar.SetActive(false);
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        PanelMisionCumplida.SetActive(false);
        BotonNivel.SetActive(false);
        BotonMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Si utilizamos el objecto pasamos al if

        if (textD.text == parrafos[index])
        {
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
        botonContinuar.SetActive(false);
        if (index < parrafos.Length - 1)
        {
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        }
        else
        {
            textD.text = "Jacob:\n" +
                    "Estoy Listo";
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

        }
        else
        {
            BotonLeer.SetActive(false);

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
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        botonQuitar.SetActive(false);

        // Activar panel de mision cumplida
        PanelMisionCumplida.SetActive(true);
        BotonNivel.SetActive(true);
        BotonMenu.SetActive(true);
    }

    // Botones de transiciones
    public void BotonSiguienteNivel()
    {
        //Reproducimos el sonido
        EfectoSonido2.Play();
        PanelMisionCumplida.SetActive(false);
        BotonNivel.SetActive(false);
        BotonMenu.SetActive(false);
        //Generar animacion de transicion con el audio
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1, 9, true);
        new WaitForSeconds(3);

        // Cargamos Escena
        StartCoroutine(CambiarEscena());
    }

    //Corrutina -> Cambio de escena
    private IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(9);
        // Cambiar de escena
        //Ya regreso /Ya termino
        // Transicion al siguiente Nivel
        SceneManager.LoadScene("Scenes/Nivel_III/nivel3Pasillo");
    }

    public void BotonIrMenu()
    {
        // Transicion al menu
        SceneManager.LoadScene("Scenes/Menus/Menuprincipal");
    }
}
