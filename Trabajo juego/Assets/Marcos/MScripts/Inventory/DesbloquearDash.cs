using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearDash : MonoBehaviour , interactive
{
    public ScriptableJugador datosJugador;
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("has desbloqueado el dash");
        datosJugador.dashDesbloqueado = true;
        this.gameObject.SetActive(false);
    }
}
