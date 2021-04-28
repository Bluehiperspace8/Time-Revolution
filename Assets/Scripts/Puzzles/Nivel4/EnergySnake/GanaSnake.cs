using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/* Codigo que dice si el jugador pierde o gana en el juego de Energy Snake
 * Autor: Diego Alejandro Juárez Ruiz
 * Luis Enrique Zamarripa
 */


public class GanaSnake : MonoBehaviour
{

    public struct DatosUsuariosStats
    {
        public string usuario;
        public string campo;
        public float stat;
    }

    public DatosUsuariosStats datosStat;
    // Start is called before the first frame update
    void Gana()
    {
        float tiempoF = Time.time;
        float tiempillo = PlayerPrefs.GetFloat("inicioSnake");
        float duracion = tiempoF - tiempillo;
        PlayerPrefs.SetFloat("inicioSnake",duracion);
        print(duracion);
        EscribirJson();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel42");
    }

    public void EscribirJson()
    {
        StartCoroutine(GuardaStats());
    }

    public IEnumerator GuardaStats()
    {
        datosStat.usuario = PlayerPrefs.GetString("username", "dummy");
        datosStat.campo = "tiempoEnergySnake";
        datosStat.stat = PlayerPrefs.GetFloat("inicioSnake");
        print(JsonUtility.ToJson(datosStat));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosStat));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/stats/agregarStats", forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        //... ya regreso porque ya termino SendWebRequest
        if (request.result == UnityWebRequest.Result.Success) //200
        {
            print("Beautiful people");
        }
        else
        {
            print("o.O");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MueveBola.instance.puntaje >= 80)
            {
                Gana();
            }
        }
    }
}
