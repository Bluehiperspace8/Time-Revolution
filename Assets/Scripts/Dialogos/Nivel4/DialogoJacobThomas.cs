using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;



/*
 Objetivo: Dialogo de Jacob final cdel juego
 Autor: Roberto Valdez Jasso
 */

public class DialogoJacobThomas : MonoBehaviour
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

    // Boton Seguir al Menu
    public GameObject BotonMenu;

    // Referencia al auido Source1(Dialogo)
    public AudioSource EfectoSonido;

    // Referencia al auido Source (Fondo)
    public AudioSource EfectoSonido1;

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
        BotonMenu.SetActive(false);
        EfectoSonido1.Play();
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
            textD.text = "\n¿Le gustaría saber por qué llegue tarde?";
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
        BotonMenu.SetActive(true);
    }


    public void EscribirJson2()
    {
        StartCoroutine(DarLogro());
    }

    // Regresamos al nivel Final al menu
    public void BotonIrMenu()
    {
        // Transicion al menu
        EscribirJson2();
        SceneManager.LoadScene("Scenes/Menus/Menuprincipal");
    }

    public IEnumerator DarLogro()
    {
        datosLogro.usuario = PlayerPrefs.GetString("username", "dummy");
        datosLogro.logro = "6";
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
}
