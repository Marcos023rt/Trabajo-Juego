using UnityEngine;

public class CartaMundo : MonoBehaviour, interactive
{
    public PlantillaCartas datosCarta; // Arrastra aqu� el ScriptableObject que representa esta carta

    public void Interactuar(GameObject jugador)
    {
        Debug.Log($"Recogiste la carta: {datosCarta.nombreC}");
        // Aqu� podr�as agregarla al inventario del jugador
        gameObject.SetActive(false); // Desaparece del mundo al recogerla
    }
}
