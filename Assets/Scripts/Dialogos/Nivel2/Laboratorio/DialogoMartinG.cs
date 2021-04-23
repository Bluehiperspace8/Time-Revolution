using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Implementar el diálogo con Martín Gómez en el laboratorio
Autor: Renata de Luna
*/

public class DialogoMartinG : MonoBehaviour
{
    public TextMeshProUGUI textD;
    [TextArea (3,30)]
    public string[] parrafos;
    int index;
    public float velParrafo;

    public GameObject botonContinuar;
    public GameObject botonSalir;

    public GameObject panelDialogo; 
    public GameObject botonConversar;

    public AudioSource sonidoConv;

    //public Image imagenFondo;

    //public GameObject martin1;
    //public GameObject martin2;
    


    // Start is called before the first frame update
    void Start()
    {
        botonSalir.SetActive(false);
        botonConversar.SetActive(false);
        panelDialogo.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (textD.text == parrafos[index])
        {
            botonContinuar.SetActive(true);
            sonidoConv.Play();
        }
    }

    IEnumerator TextDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {
            textD.text += letra;

            yield return new WaitForSeconds(velParrafo);
        }

    }

    public void SiguienteParrafo()
    {
        botonContinuar.SetActive(false);
        if (index < parrafos.Length - 1)
        {
            index ++;
            textD.text = "";
            StartCoroutine(TextDialogo());

        }else{
            textD.text = "Martín: Oye hombre, ¿estás bien? ¿Qué sucede? ¿Quieres que te traiga algo?";
            botonContinuar.SetActive(false);
            botonSalir.SetActive(true);
            //Hacer el código de fade out
            /*imagenFondo.canvasRenderer.SetAlpha(0);
            imagenFondo.gameObject.SetActive(true);
            imagenFondo.CrossFadeAlpha(1, 11, true);

            new WaitForSeconds(7);

            imagenFondo.canvasRenderer.SetAlpha(0);
            imagenFondo.gameObject.SetActive(false);
            imagenFondo.CrossFadeAlpha(0, 11, true);

            martin1.GameObject.SetActive(false);
            martin2.GameObject.SetActive(true);*/

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            botonConversar.SetActive(true);
        }else{
            botonConversar.SetActive(false);
        }
    }

    public void ActivarBotonConv()
    {
        panelDialogo.SetActive(true);
        StartCoroutine(TextDialogo());
        sonidoConv.Play();
    }

    public void ActivarBotonSalir()
    {
        panelDialogo.SetActive(false);
        botonConversar.SetActive(false);
        botonSalir.SetActive(false);
        
    }
}
