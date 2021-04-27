using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PierdeoGana : MonoBehaviour
{
    public GameObject personaje;
    // Update is called once per frame
    void Pierde()
    {
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("inicioCoreDrop");
        float duracion = tiempoF - tiempo;
        print(duracion);
        SceneManager.LoadScene("Falldown"); 
    }

    void Gana()
    {
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("inicioCoreDrop");
        float duracion = tiempoF - tiempo;
        print(duracion);
        SceneManager.LoadScene("Nivel4-3");
    }
    void Update()
    {
        if(personaje.transform.position.y >= 8f)
        {
            Pierde();
        }
        else if(personaje.transform.position.y <= -10)
        {
            Gana();
        }
    }
}
