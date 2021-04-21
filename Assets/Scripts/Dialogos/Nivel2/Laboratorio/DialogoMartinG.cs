using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoMartinG : MonoBehaviour
{
    public TextMeshProUGUI textD;
    public string[] parrafos;
    int index;
    public float velParrafo;

    public GameObject botonContinuar;
    public GameObject botonSalir;

    public GameObject panelDialogo; 
    public GameObject botonConversar;
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
        }
    }

    IEnumerator TextDialogo()
    {
        foreach (char letra in parrafos[index].ToCharArray())
        {
            textD.text += letra;

            yield return new WaitForSecodns(velParrafo);
        }

    }

    public void siguienteParrafo()
    {
        botonContinuar.SetActive(false);
        if (index < parrafos.Length - 1)
        {
            index ++;
            textD.text = "";
            StartCoroutine(TextDialogo());

        }else{
            textD.text = "";
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

    public void activarBotonConv()
    {
        panelDialogo.SetActive(true);
        StartCoroutine(TextDialogo());
    }

    public void activarBotonSalir()
    {
        panelDialogo.SetActive(false);
        botonConversar.SetActive(false);
        botonSalir.SetActive(false);
    }
}
