using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoEspacios : MonoBehaviour, interactive
{
    public ScriptableJugador datosJugador;
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("has el numero de huecos en 1");
        datosJugador.EspaciosEquipables += 1;
        this.gameObject.SetActive(false);
    }
}
