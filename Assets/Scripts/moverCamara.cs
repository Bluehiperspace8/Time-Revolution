using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la camara siga al perosnaje
 * Autores:
 * Diego Alejandro Juárez Ruiz
 * Luis Enrique Zamarripa
 */

public class moverCamara : MonoBehaviour
{
    //Nos referimos al personaje
    public GameObject personajePrincipal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Sacamos posición del personaje en x y z
        float x = Mathf.Clamp(personajePrincipal.transform.position.x, 0, 35.5f);
        float y = Mathf.Clamp(personajePrincipal.transform.position.y, 0, 9.5f);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}

