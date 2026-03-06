using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour, interactive
{
    public GameObject subidafinal;
    public ScriptableJugador datosJugador;
    private void Start()
    {
        if (datosJugador.llaveEncontrada == false)
        {
            subidafinal.SetActive(false);
        }
        if (datosJugador.llaveEncontrada == true)
        {
            subidafinal.SetActive(true);
        }
    }
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("has desbloqueado la llave");
        datosJugador.llaveEncontrada = true;
        this.gameObject.SetActive(false);
        subidafinal.SetActive(true);
    }
}
