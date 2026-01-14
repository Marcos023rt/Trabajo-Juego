using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DatosJugador", menuName = "Jugador")]
public class ScriptableJugador : ScriptableObject
{
    public int Vida;
    public int EspaciosEquipables;
    public int Dinero;

    public bool curarse = false;
    public int contadorGolpes;
}
