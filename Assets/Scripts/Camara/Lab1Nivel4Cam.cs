using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la camara siga al perosnaje
 * Autores:
 * Diego Alejandro Juarez Ruiz
 * Luis Enrique Zamarripa
 */

public class Lab1Nivel4Cam : MonoBehaviour
{
    //Nos referimos al personaje
    public GameObject personajePrincipal;

    // Update is called once per frame
    void Update()
    {
        //Sacamos posición del personaje en x y z
        float x = Mathf.Clamp(personajePrincipal.transform.position.x, 0, 34.7f);
        //float y = Mathf.Clamp(personajePrincipal.transform.position.y, 0, 3.5f);
        float z = transform.position.z;
        transform.position = new Vector3(x, 0, z);
    }
}
