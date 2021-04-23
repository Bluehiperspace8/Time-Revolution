using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Realizado por Diego Alejandro Juárez Ruiz A01379566
 * Código que mueve el tileset
 */

public class Movertile : MonoBehaviour
{
    // Variable velocidad horizontal
    public float maxVelocidadx = 2; //Movimiento horizonta
    private float movhor = 1;

    private Rigidbody2D rigidbodytile;

    // Start is called before the first frame update
    void Start()
    {
        // Incializar Componentes
        rigidbodytile = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal del hongo
        rigidbodytile.velocity = new Vector2(rigidbodytile.velocity.x,maxVelocidadx * movhor);
    }
}