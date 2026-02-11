using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorAnimator : MonoBehaviour
{
    public  Rigidbody2D rb;
    public Animator animacionJugador;
    private bool moverse;
    
    // Update is called once per frame
    void Update()
    {
        moverse = rb.velocity.magnitude > 0.1f; //me dice si se esta moviendo o no
        animacionJugador.SetBool("Moviendose", moverse); //hace la animacion si se esta moviendo

        if (Input.GetKeyDown(KeyCode.W)) //animacion de curarse
        {
            animacionJugador.SetBool("Curandose", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animacionJugador.SetBool("Curandose", false);
        }
    }
}
