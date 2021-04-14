using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 Objetivo: Pasar a la transicion del fabrica y escena final (Portal) del Prota
 Autor: Roberto Valdez Jasso
 */

public class Transicion1_3 : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        // Declarando el inicio
        //No estara prendido hasta que el objeto sea utilizado
        BotonLeer.SetActive(false);
        PanelDialogo.SetActive(false);
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
        SceneManager.LoadScene("Scenes/Nivel_I/Portal");
        Destroy(gameObject, t: 0.1f);
    }

    public void botonQuedarse()
    {
        PanelDialogo.SetActive(false);
        BotonLeer.SetActive(false);

    }
}
