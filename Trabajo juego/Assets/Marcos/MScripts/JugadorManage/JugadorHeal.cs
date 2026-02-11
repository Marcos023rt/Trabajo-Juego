using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorHeal : MonoBehaviour
{
    public UIJuego uijuego;
    public ScriptableJugador datosJugador;
    public float tiempoNecesario;
    float tiempoPulsado;
    public int cura;

    public int numeroDeGolpesParaCurarse;
    
    // Update is called once per frame
    void Update()
    {
        if (datosJugador.contadorGolpes >= numeroDeGolpesParaCurarse)
        {
            actualizarCurarse();
        }
        
        if (datosJugador.curarse == true)
        {
            Curarse();
        }
        
    }
    public void actualizarCurarse()
    {
        Debug.Log("Se puede curar");
        datosJugador.curarse = true;
        datosJugador.contadorGolpes = 0;
    }
    public void Curarse()
    {
        if (datosJugador.VidaActual >= datosJugador.vidaMaxima)
        {
            Debug.Log("Su vida es la maxima");
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                tiempoPulsado += Time.deltaTime;
                //Debug.Log(tiempoPulsado);
                if (tiempoPulsado >= tiempoNecesario)
                {
                    Debug.Log("El jugador se ha curado");
                    datosJugador.VidaActual += cura;
                    datosJugador.curarse = false;
                    uijuego.cambiarVidaUI();
                }
            }
        }
    }
}
