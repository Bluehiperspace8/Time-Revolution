using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


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
            textD.text = "AHHH!!!!";
            botonContinuar.SetActive(false);
            botonQuitar.SetActive(true);
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
        // Transicion al siguiente Nivel
        SceneManager.LoadScene("Scenes/Nivel_II/nivel2");
    }

    public void BotonIrMenu()
    {
        // Transicion al menu
        SceneManager.LoadScene("Scenes/Menus/Menuprincipal");
    }


}

