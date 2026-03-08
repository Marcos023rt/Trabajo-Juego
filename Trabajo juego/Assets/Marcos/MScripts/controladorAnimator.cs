using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimator : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animacionJugador;

    private bool dasheando;

    void Update()
    {
        float velocidad = rb.velocity.magnitude;
        animacionJugador.SetFloat("movimiento", velocidad);


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animacionJugador.SetBool("saltando", true);
        }
        if (rb.velocity.y <= 0.01)
        {
            animacionJugador.SetBool("saltando", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dasheando = true;
            animacionJugador.SetBool("dasheando", true);
        }
        else
        {

            dasheando = false;
            animacionJugador.SetBool("dasheando", false);
        }


       
        if (Input.GetKeyDown(KeyCode.W))
        {
            animacionJugador.SetBool("curandose", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animacionJugador.SetBool("curandose", false);
        }
    }
}