using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Guarda al usuario en PlayerPrefs
 * Autor: Luis Enrique Zamarripa
 * Diego Alejandro Juarez Ruiz
 */

public class UsuarioSave : MonoBehaviour
{
    //Campos con la informacion de nombre y puntos
    public Text textoUsuario;
    public Text textoPassword;
    public Text resultado;

    //Nickname y password jugador
    public string user;
    public string password;

    //Encapsular los datos -> JSON
    public struct DatosUsuarios
    {
        public string usuario;
        public string contrasena;
    }

    public DatosUsuarios datos;

    public void EscribirJSON()    //Boton
    {
        //Concurrente
        StartCoroutine(BotonLogin());      //'Paralelo'

    }

    private IEnumerator BotonLogin()     //Enviar datos en formato JSON
    {
        datos.usuario = textoUsuario.text;
        datos.contrasena = textoPassword.text;
        print(JsonUtility.ToJson(datos));
        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos));
        UnityWebRequest request = UnityWebRequest.Post("http://3.133.137.226:8080/estudiante/verificarLogin", forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta, espera...
        //... ya regreso porque ya termino SendWebRequest
        if (request.result == UnityWebRequest.Result.Success) //200
        {
            string textoPlano = request.downloadHandler.text;   //Datos descargados de la RED
            resultado.text = textoPlano;
            yield return new WaitForSeconds(3);
            if (textoPlano == "Acceso concedido")
            {
                PlayerPrefs.SetString("username", datos.usuario);
                SceneManager.LoadScene("Menuprincipal");
            } 
            else if(textoPlano == "Acceso denegado. Usuario o contraseña incorrectos")
            {
                SceneManager.LoadScene("LoginEscena");
            }
        }
        else
        {
            print("o.O");
        }
    }
    public void AgregarJugador()
    {
        Application.OpenURL("http://3.133.137.226:8080/estudiante/agregarJugador");
    }


}
