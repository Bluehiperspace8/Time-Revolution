using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Objetivo: Controlador del movimiento de la bola
 * Autor: Diego Alejandro Juarez Ruiz
 * Autor: Luis Enrique Zamarripa
 * Referencia a: Hector Pulido
 * Youtube: https://youtu.be/W7tHwE8g11w
 */

public class MueveBola : MonoBehaviour
{
    enum dir
    {
        right,
        up,
        down,
        left
    }

    dir direction;

    public List<Transform> tailing;
    public float framerate = 0.2f;
    public float stepRate;
    private float tempo;
    public int puntaje = 3;
    public static MueveBola instance;
    public GameObject energia;
    public AudioSource powerup;
    public int agrega;
    public Vector2 fronteraY;
    public Vector2 fronteraX;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InvokeRepeating("Move", 1, framerate);
        tempo = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            direction = dir.left;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            direction = dir.up;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            direction = dir.right;
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            direction = dir.down;
        tempo -= Time.deltaTime;
        if (tempo < 0)
        {
            puntaje -= 1;
            if(puntaje <= 0)
            {
                float tiempoF = Time.time;
                float tiempillo = PlayerPrefs.GetFloat("inicioSnake");
                float duracion = tiempoF - tiempillo;
                print(duracion);
                SceneManager.LoadScene("Energysnake");
            }
            HUD.instance.ActualizaEnergias();
            tempo = 2;
        }

    }
    void Move()
    {
        lastPos = transform.position;

        Vector3 nextPos = Vector3.zero;

        if (direction == dir.down)
            nextPos = Vector2.down;
        else if (direction == dir.left)
            nextPos = Vector2.left;
        else if (direction == dir.up)
            nextPos = Vector2.up;
        else if (direction == dir.right)
            nextPos = Vector2.right;

        nextPos *= stepRate;
        transform.position += nextPos;


        MoveTail();
    }
    Vector3 lastPos;
    void MoveTail()
    {
        for (int i = 0; i < tailing.Count; i++)
        {
            Vector3 temp = tailing[i].position;
            tailing[i].position = lastPos;
            lastPos = temp;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            float tiempoF = Time.time;
            float tiempillo = PlayerPrefs.GetFloat("inicioSnake");
            float duracion = tiempoF - tiempillo;
            print(duracion);
            SceneManager.LoadScene("EnergySnake");
        }
        else if (col.CompareTag("Nuclear") || col.CompareTag("Agua") || col.CompareTag("Sol")  || col.CompareTag("Aire"))
        {
            powerup.Play();
            if (col.CompareTag("Nuclear"))
            {
                agrega = 6;
            } else if (col.CompareTag("Agua"))
            {
                agrega = 4;
            } else if (col.CompareTag("Aire"))
            {
                agrega = 3;
            } else if (col.CompareTag("Sol"))
            {
                agrega = 2;
            }
            for (int i = 0; i <= agrega; i++)
            {
                tailing.Add(Instantiate(energia, tailing[tailing.Count - 1].position, Quaternion.identity).transform);
                puntaje += 1;
            }
            HUD.instance.ActualizaEnergias();
            col.transform.position = new Vector2(Random.Range(fronteraX.x, fronteraX.y), Random.Range(fronteraY.x, fronteraY.y));
        }
    }
}