using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 Objetivo:  Reproduce el efecto de fade in
 Autor: Roberto Valdez Jasso
 */
public class FadeIn : MonoBehaviour
{
    public Image imagenFondo;


    // Start is called before the first frame update
    void Start()
    {
        imagenFondo.CrossFadeAlpha(0, 2, true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
