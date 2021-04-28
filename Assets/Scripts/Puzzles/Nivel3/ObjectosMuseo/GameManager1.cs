using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/*
CLase Game Manager para control de Puzzle
Autor: Roberto Valdez Jasso
*/

public class GameManager1 : MonoBehaviour
{
    //--------------------------------------------------------------//
    // Variable --//
    //Interacion Usuario
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

    //Panel Juego
    public GameObject PanelJuego;

    // Boton Lectura
    public GameObject BotonLeer;

    public GameObject BotonFinalizar;



    //--------------------------------------------------------------//
    // Variable --//
    //Puzzle:
    //Sonido
    [SerializeField] private AudioClip sonidoCorrecto = null;
    [SerializeField] private AudioClip sonidoIncorrecto = null;
    //Color
    [SerializeField] private Color colorCorrecto = Color.black;
    [SerializeField] private Color colorIncorrecto = Color.black;
    //Tiempo de Espera
    [SerializeField] private float m_tiempoEspera = 0.0f;
    //Preguntas
    private PreguntasBD1 m_preguntaBd = null;
    private PreguntasUI1 m_preguntaUI = null;
    private AudioSource m_audioSource = null;
    private int contador2 = 0;
    //--------------------------------------------------------------//


    //--------------------------------------------------------------//
    // START GENERAL
    void Start()
    {
        // Referencias
        m_preguntaBd = GameObject.FindObjectOfType<PreguntasBD1>();
        m_preguntaUI = GameObject.FindObjectOfType<PreguntasUI1>();
        m_audioSource = GameObject.FindObjectOfType<AudioSource>();

        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
        PanelJuego.SetActive(false);
        BotonFinalizar.SetActive(false);

        //Esto debe estar en el boton de si
        //NextQuestion();

    }
    //--------------------------------------------------------------//


    //--------------------------------------------------------------//
    //Interaacion Usuario
    // Codigo
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
        textD.text = "¿Listo para contestar las preguntas?";

        botonSi.SetActive(true);
        botonNo.SetActive(true);



    }

    //Cambiar de mapa
    public void botoncambiar()
    {
        //Apagamos todos los botones de usuario
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);
        botonSi.SetActive(false);
        botonNo.SetActive(false);
        int intentos = PlayerPrefs.GetInt("Intentos3", 1);
        if (intentos == 1)
        {
            PlayerPrefs.SetInt("Intentos3", 1);
            PlayerPrefs.Save();
        }
        print(PlayerPrefs.GetInt("Intentos3"));
        //Prendemos los de juego
        PanelJuego.SetActive(true);
        //Iniciamos con la Corrutina
        NextQuestion();

    }

    //Aparece una vez terminado el puzzle
    public void botonterminado()
    {
        PanelDialogo.SetActive(false);
        BotonFinalizar.SetActive(false);
        // Activando el Collider para la platica final
        Destroy(gameObject, t: 0.1f);
    }

    public void botonQuedarse()
    {
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);

    }


    //--------------------------------------------------------------//


    //--------------------------------------------------------------//
    //Puzzle
    // Codigo
    private void NextQuestion()
    {
        //print("Ejecutando nexquestion");
        m_preguntaUI.Construct(m_preguntaBd.GETRandom(), GiveAnswer); 
    }

    private void GiveAnswer(BotonesOpciones1 opcionBoton)
    {
        StartCoroutine(RutinaPregunta(opcionBoton));

    }

    // Corruntina

    private IEnumerator RutinaPregunta(BotonesOpciones1 opcionBoton)
    {
        if (m_audioSource.isPlaying)
        {
            m_audioSource.Stop();
        }
        // operador ternario
        //Cambiio de Sonido
        m_audioSource.clip = opcionBoton.Opcion.opcionCorrecta ? sonidoCorrecto : sonidoIncorrecto;
        //Cambio de Color
        opcionBoton.SetColor(opcionBoton.Opcion.opcionCorrecta ? colorCorrecto : colorIncorrecto);


        //Reproduccion de Sonido
        m_audioSource.Play();

        // Esperar tiempo por los efectos

        yield return new WaitForSeconds(m_tiempoEspera);

        // Y regresamos



        if (opcionBoton.Opcion.opcionCorrecta)
        {

            NextQuestion();
            contador2++;


        }
        else
        {
            int intentos = PlayerPrefs.GetInt("Intentos3");
            intentos += 1;
            PlayerPrefs.SetInt("Intentos3", intentos);
            // En caso que pierda,este vuelva a hacer el puzzle desde cero
            SceneManager.LoadScene("Scenes/Nivel_III/nivel3Museo");
        }
        // En caso que termine, este
        if (contador2 == 20)
        {
            PanelJuego.SetActive(false);
            PanelDialogo.SetActive(true);
            textD.text = " ";
            BotonFinalizar.SetActive(true);
            int intentos = PlayerPrefs.GetInt("Intentos3");
            intentos += 1;
            PlayerPrefs.SetInt("Intentos3", intentos);
        }




    }
}
