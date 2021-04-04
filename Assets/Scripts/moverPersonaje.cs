using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla el movimiento del personaje
 * Autores:
 * Luis Enrique Zamarripa 
 * Diego Alejandro Juarez
 */

public class moverPersonaje : MonoBehaviour
{
    // variables
    public float maxVelocidadx = 10; //Mov horizonta 
    public float maxVelocidady = 6; //Mov vertical
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        // Incializar variables
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");  // [-1,1]
        rigidbody.velocity = new Vector2(movHorizontal * maxVelocidadx, rigidbody.velocity.y);

        //Salto
        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0 && pruebaPiso.estaenpiso)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVelocidady);
        }
    }
}

