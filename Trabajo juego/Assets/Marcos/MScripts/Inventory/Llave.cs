using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour, interactive
{
    public ScriptableJugador datosJugador;
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("has desbloqueado la llave");
        datosJugador.llaveEncontrada = true;
        this.gameObject.SetActive(false);
    }
}
