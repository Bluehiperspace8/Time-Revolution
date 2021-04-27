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
    //String que contendrá todos los diálogos 
    public string[] parrafos;
    //índice de los párrafos
    int index;
    //Velocidad a la que aparecerán los párrafos
    public float velParrafo;
    //Botones
    public GameObject botonContinuar;
    public GameObject botonSalir;

    public GameObject panelDialogo; 
    public GameObject botonConversar;
    //Sonido del diálogo
    public AudioSource sonidoConv;

    public Image imagenFondo;
    //Martin que se desactivará y activará
    public GameObject martin1;
    public GameObject martin2;

  
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
            //Siguiente párrafo de la conversación
            index ++;
            textD.text = "";
            StartCoroutine(TextDialogo());

        }else{
            //Última línea de la conversación
            textD.text = "Martín:\n"+
                "Oye hombre, ¿estás bien? ¿Qué sucede? ¿Quiéres que te traiga algo?";
            botonContinuar.SetActive(false);
            botonSalir.SetActive(true);

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

    public void OnTriggerExit2D(Collider2D collsion)
    {
        if (collsion.CompareTag("Player"))
        {
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
        //Desactivar panel y botones
        panelDialogo.SetActive(false);
        botonConversar.SetActive(false);
        botonSalir.SetActive(false);

        //Efecto fade out
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1, 11, true);
        //Se desactiva el primer Martin para que ya no se muestre en la escena después del desmayo. 
        martin1.SetActive(false);
        new WaitForSeconds(3);

        
        StartCoroutine(EfectoDadeIn());
        //Se activa el segundo Martin para que esté en la escena
        martin2.SetActive(true);

        
        
    }

    public IEnumerator EfectoDadeIn()
    {
        //Efecto fade in
        yield return new WaitForSeconds(11);
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(false);
        imagenFondo.CrossFadeAlpha(0, 15, true);
    }
}
