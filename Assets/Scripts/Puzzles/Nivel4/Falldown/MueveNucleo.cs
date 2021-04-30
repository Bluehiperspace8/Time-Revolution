using System.Collections.Generic;
using UnityEngine;

/*
 * Controlador del nucleo en CoreDrop
 * Diego Alejandro Juarez Ruiz
 * Luis Enrique Zamarripa Marin
 */

public class MueveNucleo : MonoBehaviour
{
    // variables
    public float maxVelocidadx = 10; //Mov horizonta 
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
    }
}

