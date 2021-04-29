using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Ultima platica de Amelie en el pasillo Nivel II
 * Autor: Roberto Valdez Jasso
 * Autor: Diego Alejandro Juarez Ruiz
 * Autor: Luis Enrique Zamarripa
 * Referencia a: Drosgame
 * Youtube: https://youtu.be/FjoL4ufZmXc
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

    //Encapsular los datos -> JSON
    public struct DatosUsuarios
    {
        public string usuario;
        public string nivel;
        public float tiempo;
    }

    public DatosUsuarios datosPartida;

    public struct DatosUsuariosLogro
    {
        public string usuario;
        public string logro;
    }

    public DatosUsuariosLogro datosLogro;

    public struct DatosUsuariosStats
    {
        public string usuario;
        public string campo;
        public int stat;
    }

    public DatosUsuariosStats datosStat;

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
                    "Estoy listo.";
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
        imagenFondo.CrossFadeAlpha(1, 7, true);
        new WaitForSeconds(3);

        // Cargamos Escena
        StartCoroutine(CambiarEscena());
    }

    //Corrutina -> Cambio de escena
    private IEnumerator CambiarEscena()
    {
        yield return new WaitForSeconds(7);
        // Cambiar de escena
        //Ya regreso /Ya termino
        // Transicion al siguiente Nivel
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("tiemponivel2");
        float duracion = tiempoF - tiempo;
        PlayerPrefs.SetFloat("tiemponivel2", duracion);
        print(PlayerPrefs.GetFloat("tiemponivel2"));
        EscribirJson();
        EscribirJson2();
        EscribirJson3();
        SceneManager.LoadScene("Scenes/Nivel_III/nivel3Pasillo");
    }

    public void EscribirJson()
    {
        StartCoroutine(GuardarPartida());
    }

    public void EscribirJson2()
    {
        StartCoroutine(DarLogro());
    }

    public void EscribirJson3()
    {
        StartCoroutine(GuardaStats());
    }

    public IEnumerator DarLogro()
    {
        datosLogro.usuario = PlayerPrefs.GetString("username", "dummy");
        datosLogro.logro = "2";
        print(JsonUtility.ToJson(datosLogro));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosLogro));
        UnityWebRequest request = UnityWebRequest.Post("http://3.133.137.226:8080/logros/agregarLogroJugador", forma);
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
        datosPartida.nivel = "2";
        datosPartida.tiempo = PlayerPrefs.GetFloat("tiemponivel2");
        print(JsonUtility.ToJson(datosPartida));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosPartida));
        UnityWebRequest request = UnityWebRequest.Post("http://3.133.137.226:8080/partida/agregarPartida", forma);
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

    public IEnumerator GuardaStats()
    {
        datosStat.usuario = PlayerPrefs.GetString("username", "dummy");
        datosStat.campo = "intentosCuestionario2";
        datosStat.stat = PlayerPrefs.GetInt("Intentos2");
        print(JsonUtility.ToJson(datosStat));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosStat));
        UnityWebRequest request = UnityWebRequest.Post("http://3.133.137.226:8080/stats/agregarStats", forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        //... ya regreso porque ya termino SendWebRequest
        if (request.result == UnityWebRequest.Result.Success) //200
        {
            print("Beautiful Stat");
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
        float tiempo = PlayerPrefs.GetFloat("tiemponivel2");
        float duracion = tiempoF - tiempo;
        PlayerPrefs.SetFloat("tiemponivel2", duracion);
        print(PlayerPrefs.GetFloat("tiemponivel2"));
        EscribirJson();
        EscribirJson2();
        EscribirJson3();
        SceneManager.LoadScene("Scenes/Menus/Menuprincipal");
    }
}
