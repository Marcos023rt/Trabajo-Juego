
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Carta")]
public class PlantillaCartas : ScriptableObject
{
    public string nombreC;
    [Tooltip("Escribir el texto que vera el jugador en el inventario al seleccionar la carta")][TextArea]public string descripcion;

    [Tooltip("Insertar el sprite correspondiente")]public Sprite sprite;
    [Tooltip("Cuanto cuesta comprar las cartas")]public int precio;
    [Tooltip("Los espacios que ocupa al ser equipado")]public int espaciosOcupa;
    [Tooltip("Poner el numero de carta al que corresponde")]public int NumeroCarta;
    [HideInInspector] public bool CartaEncontrada;
   
}
