using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoMartin2 : MonoBehaviour
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
            textD.text = "Martín: ¿Qué tal que tú me ayudas en abrir la puerta, lo que yo intento abrir un portal como realmente lo quería hacer al inicio?";
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
