using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

/*
 Clase Botone Opciones
 Autor: Roberto Valdez Jasso
 */

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class BotonesOpciones1 : MonoBehaviour
{
    //---------------------------------------------------------------//
    // PUZZLE
    // Variables ---//
    private Text texto = null;
    private Button boton = null;
    private Image imagen = null;
    private Color colorOriginal = Color.black;

    public Opciones2 Opcion { get; set; }

    //---------------------------------------------------------------//

    //---------------------------------------------------------------//
    // PUZZLE
    //Codigo
    private void Awake()
    {
        boton = GetComponent<Button>();
        imagen = GetComponent<Image>();
        texto = transform.GetChild(0).GetComponent<Text>();
        colorOriginal = imagen.color;
    }

    public void Construct(Opciones2 opcion, Action<BotonesOpciones1> callback)
    {
        texto.text = opcion.texto;
        boton.onClick.RemoveAllListeners();
        boton.enabled = true;
        imagen.color = colorOriginal;

        Opcion = opcion;

        boton.onClick.AddListener(delegate
        {
            callback(this);
        });
    }


    public void SetColor(Color c)
    {
        boton.enabled = false;
        imagen.color = c;
    }




    //---------------------------------------------------------------//




}
