using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Permite modificar el parametro velocidad de animator Sirve para hacer el movimiento
 * Autores:
 * Luis Enrique Zamarripa
 * Diego Alejandro Juarez
 */
public class cambioAnimacion : MonoBehaviour
{
    public Rigidbody2D rb2D;
    // Animator
    private Animator anim; //para el animator y definir el parametro velocidad
    // Sprite renderees para cambiar la dirección 
    private SpriteRenderer sprrende;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprrende = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat(name: "Velocidad", velocidad);

        //orientación 
        if (rb2D.velocity.x > 0)
        {
            sprrende.flipX = false;
        }
        else if (rb2D.velocity.x < 0)
        {
            sprrende.flipX = true;
        }
        //saltando
        anim.SetBool(name: "Salto", !pruebaPiso.estaenpiso);
    }
}
