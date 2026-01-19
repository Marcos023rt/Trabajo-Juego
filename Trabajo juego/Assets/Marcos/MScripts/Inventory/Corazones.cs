using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour, interactive
{
    public ScriptableJugador datosJugador;
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("has aumentado tu vida maxima en 1");
        datosJugador.vidaMaxima += 1;
        this.gameObject.SetActive(false);
    }
}
