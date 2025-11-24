using UnityEngine;

public class CartaMundo : MonoBehaviour, interactive
{
    public PlantillaCartas datosCarta; // Arrastra aquí el ScriptableObject que representa esta carta

    public void Interactuar(GameObject jugador)
    {
        Debug.Log($"Recogiste la carta: {datosCarta.nombreC}");
        // Aquí podrías agregarla al inventario del jugador
        gameObject.SetActive(false); // Desaparece del mundo al recogerla
        datosCarta.CartaEncontrada = true;
    }
}
