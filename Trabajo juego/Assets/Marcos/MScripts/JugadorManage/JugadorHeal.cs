using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorHeal : MonoBehaviour
{
    public ScriptableJugador datosJugador;
    public float tiempoNecesario;
    float tiempoPulsado;
    public int cura = 2;

    public int numeroDeGolpesParaCurarse = 3;
    
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
       
        if (Input.GetKey(KeyCode.E))
        {
            tiempoPulsado += Time.deltaTime;
            Debug.Log(tiempoPulsado);
            if (tiempoPulsado >= tiempoNecesario)
            {      
                Debug.Log("El jugador se ha curado");
                datosJugador.Vida += cura;
                datosJugador.curarse = false;
            }
        }  
    }
}
