using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/* 
 * Codigo que dice si el jugador pierde o gana en el juego de CoreDrop
 * Autor: Diego Alejandro Juarez Ruiz
 * Luis Enrique Zamarripa
 */

public class PierdeoGana : MonoBehaviour
{
    public struct DatosUsuariosStats
    {
        public string usuario;
        public string campo;
        public float stat;
    }

    public DatosUsuariosStats datosStat;
    public GameObject personaje;
    // Update is called once per frame
    void Pierde()
    {
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("inicioCoreDrop");
        float duracion = tiempoF - tiempo;
        PlayerPrefs.SetFloat("inicioCoreDrop", duracion);
        print(duracion);
        SceneManager.LoadScene("Falldown"); 
    }

    void Gana()
    {
        float tiempoF = Time.time;
        float tiempo = PlayerPrefs.GetFloat("inicioCoreDrop");
        float duracion = tiempoF - tiempo;
        PlayerPrefs.SetFloat("inicioCoreDrop", duracion);
        print(duracion);
        EscribirJson();
        SceneManager.LoadScene("Nivel4-3");
    }
    public void EscribirJson()
    {
        StartCoroutine(GuardaStats());
    }

    public IEnumerator GuardaStats()
    {
        datosStat.usuario = PlayerPrefs.GetString("username", "dummy");
        datosStat.campo = "tiempoCoreDrop";
        datosStat.stat = PlayerPrefs.GetFloat("inicioCoreDrop");
        print(JsonUtility.ToJson(datosStat));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosStat));
        UnityWebRequest request = UnityWebRequest.Post("http://3.133.137.226:8080/stats/agregarStats", forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        //... ya regreso porque ya termino SendWebRequest
        if (request.result == UnityWebRequest.Result.Success) //200
        {
            print("Beautiful Droping");
        }
        else
        {
            print("o.O");
        }
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
