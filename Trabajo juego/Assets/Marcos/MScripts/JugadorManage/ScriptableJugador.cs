using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DatosJugador", menuName = "Jugador")]
public class ScriptableJugador : ScriptableObject
{
    public int VidaActual;
    public int vidaMaxima = 6;
        
    public bool curarse = false;
    public int contadorGolpes;

    public bool dashDesbloqueado = false;
    public bool llaveEncontrada = true;

    public int EspaciosEquipables = 6;
    public int espaciosOcupados = 0;
    public int Dinero;
}
