using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecer01 : MonoBehaviour
{
    public Transform player;
    public Transform spawn01;
    public Transform spawn02;
    public ScriptableJugador datosJugador;
    // Start is called before the first frame update
    void Awake()
    {
        if (datosJugador.NivelActual == "Nivel 00")
        {
            player.position = spawn01.position;
        }
        if (datosJugador.NivelActual == "Nivel 02")
        {
            player.position = spawn02.position;
        }
    }
}
