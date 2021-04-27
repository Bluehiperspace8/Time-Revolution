using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanaSnake : MonoBehaviour
{
    // Start is called before the first frame update
    void Gana()
    {
        float tiempoF = Time.time;
        float tiempillo = PlayerPrefs.GetFloat("inicioSnake");
        float duracion = tiempoF - tiempillo;
        print(duracion);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel42");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MueveBola.instance.puntaje >= 10)
            {
                Gana();
            }
        }
    }
}
