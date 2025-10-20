
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Carta")]
public class PlantillaCartas : ScriptableObject
{
    public string nombreC;
    [TextArea]public string descripcion;

    public Sprite sprite;
    public int precio;
    public int NumeroCarta;
    public int espaciosOcupa;
}
