using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Prueba si el colider esta dentro o fuera de una plataforma
 * Autores:
 * Luis Enrique Zamarripa
 * Diego Alejandro Ruiz
 */

public class pruebaPiso : MonoBehaviour
{
    public static bool estaenpiso = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        estaenpiso = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        estaenpiso = false;
    }
}

