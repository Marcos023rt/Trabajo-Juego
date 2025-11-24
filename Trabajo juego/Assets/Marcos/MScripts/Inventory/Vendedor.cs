using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vendedor : MonoBehaviour, interactive
{
    [Header("Cartas que vende")]
    [Tooltip("Meter las diferentes cartas que se han creado del ScriptableObjet")] public PlantillaCartas[] cartasDisponibles; // Arrastra aquí tus ScriptableObjects
    public GameObject pvendedor;
    public TMP_Text textodescripcion;
    #region Botones
    [Header("Botones")]
    public Button[] BotonesComprar = new Button[4];
    
    #endregion
    private void Start()
    {
        pvendedor.SetActive(false);
    }
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("Has hablado con el vendedor.");
        MostrarCartas();
    }

    void MostrarCartas()
    {
        pvendedor.SetActive(true);
        Time.timeScale = 0f;
      
    }
    private void comprobadorDinero()
    {
        //aqui habra que mirar el dinero del jugador y asi limitar cuando puede comprar las cartas, llamarlo al interactuar con el jugador y cuando compre una carta
    }
    public void SalirVendedor()
    {
        pvendedor.SetActive(false);
        Time.timeScale = 1f;
    }
    public void mostrarDescripcion(int numeroCarta)
    {
        textodescripcion.text = cartasDisponibles[numeroCarta].descripcion;
    }
    public void comprarCarta(int numeroCarta)
    {
        cartasDisponibles[numeroCarta].CartaEncontrada = true;
        Debug.Log($"La carta: {numeroCarta}, esta en estado {cartasDisponibles[numeroCarta].CartaEncontrada} del inventario");
        BotonesComprar[numeroCarta].interactable = false;

    }

}
