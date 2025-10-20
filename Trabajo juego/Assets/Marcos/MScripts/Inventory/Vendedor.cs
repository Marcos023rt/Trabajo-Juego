using UnityEngine;

public class Vendedor : MonoBehaviour, interactive
{
    [Header("Cartas que vende")]
    public PlantillaCartas[] cartasDisponibles; // Arrastra aquí tus ScriptableObjects

    public void Interactuar(GameObject jugador)
    {
        Debug.Log("Has hablado con el vendedor.");
        MostrarCartas();
    }

    void MostrarCartas()
    {
        foreach (var carta in cartasDisponibles)
        {
            Debug.Log($"🃏 {carta.nombreC} - {carta.precio} monedas");
        }

        // Aquí más habra que abrir un panel de ui donde esten todas las cartas y sus huecos, asi se vera cuales tiene, tambien sus huecos equipados
    }
}
