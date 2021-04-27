using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;



/*
 Objetivo: Dialogo de Jacob final con aparecion de portal
 Autor: Roberto Valdez Jasso
 */

public class PlaticaPortal : MonoBehaviour
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

    // Portal
    public GameObject Portal;

    //Protagonista
    public GameObject Prota;



    // PANEL MISION CUMPLIDA
    public GameObject PanelMisionCumplida;

    // Boton Seguir al Siguiente Nivel

    public GameObject BotonNivel;
    public GameObject BotonMenu;

    // Referencia al auido Source1(Dialogo)
    public AudioSource EfectoSonido;

    // Referencia al auido Source (Portal)
    public AudioSource EfectoSonido1;

    // Referencia al auido Source (Portal2 pasando al siguiente nivel)
    public AudioSource EfectoSonido2;

    //Imagen que dara la transicion en negro a la siguiente escena
    public Image imagenFondo;

    //Encapsular los datos -> JSON
    public struct DatosUsuarios
    {
        public string usuario;
        public string nivel;
    }

    public DatosUsuarios datosPartida;

    public struct DatosUsuariosLogro
    {
        public string usuario;
        public string logro;
    }

    public DatosUsuariosLogro datosLogro;

    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        botonQuitar.SetActive(false);
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        PanelMisionCumplida.SetActive(false);
        Portal.SetActive(false);
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
            textD.text = "¡¡¡¡AHHH!!!!";
            botonContinuar.SetActive(false);
            botonQuitar.SetActive(true);
            EfectoSonido1.Play();
            //Activar Portal
            Portal.SetActive(true);
            Prota.SetActive(false);

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
        imagenFondo.CrossFadeAlpha(1, 11, true);
        new WaitForSeconds(3);

        // Cargamos Escena
        StartCoroutine(CambiarEscena());
    }

    //Corrutina -> Cambio de escena
    private IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(11);
        // Cambiar de escena
        //Ya regreso /Ya termino
        // Transicion al siguiente Nivel
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("tiemponivel1");
        float duracion = tiempoF - tiempo;
        PlayerPrefs.SetFloat("tiemponivel1", duracion);
        print(PlayerPrefs.GetFloat("tiemponivel1"));
        EscribirJson();
        EscribirJson2();
        SceneManager.LoadScene("Scenes/Nivel_II/Laboratorio");
    }

    public void EscribirJson()
    {
        StartCoroutine(GuardarPartida());
    }

    public void EscribirJson2()
    {
        StartCoroutine(DarLogro());
    }

    public IEnumerator DarLogro()
    {
        datosLogro.usuario = PlayerPrefs.GetString("username", "dummy");
        datosLogro.logro = "1";
        print(JsonUtility.ToJson(datosLogro));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosLogro));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/logros/agregarLogroJugador", forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        //... ya regreso porque ya termino SendWebRequest
        if (request.result == UnityWebRequest.Result.Success) //200
        {
            print("Beautiful");
        }
        else
        {
            print("o.O");
        }
    }

    public IEnumerator GuardarPartida()
    {
        datosPartida.usuario = PlayerPrefs.GetString("username", "dummy");
        datosPartida.nivel = "1";
        print(JsonUtility.ToJson(datosPartida));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosPartida));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/partida/agregarPartida", forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        //... ya regreso porque ya termino SendWebRequest
        if (request.result == UnityWebRequest.Result.Success) //200
        {
            print("Beautiful");
        }
        else
        {
            print("o.O");
        }
    }

    public void BotonIrMenu()
    {
        // Transicion al menu
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("tiemponivel1");
        float duracion = tiempoF - tiempo;
        PlayerPrefs.SetFloat("tiemponivel1", duracion);
        print(PlayerPrefs.GetFloat("tiemponivel1"));
        EscribirJson();
        EscribirJson2();
        SceneManager.LoadScene("Scenes/Menus/Menuprincipal");
    }


}

