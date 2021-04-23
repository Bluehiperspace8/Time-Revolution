using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanaSnake : MonoBehaviour
{
    // Start is called before the first frame update
    void Gana()
    {
        print("Ganste wwwwwiiiiiiiiii");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Energysnake");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (MueveBola.instance.puntaje >= 88)
            {
                Gana();
            }
        }
    }
}
