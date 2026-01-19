using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZonaDescanso : MonoBehaviour, interactive
{
    //falta hacer algo para que sepa cuantos espacios lleva metidos en el invetario ( no hay nada creado hacerlo e ir guardando la informacion)
    //falta hacer que los sprites de los que estan equipados se actualicen en el start (sos)
    #region Data
    [Header("Cartas equipables")]
    public ScriptableJugador datosJugador;
    [Header("Cartas equipables")]
    [Tooltip("Meter las diferentes cartas que se han creado del ScriptableObjet")] public PlantillaCartas[] cartasDisponibles;

    [Header("Inventario")]
    public GameObject pinventario;
    public TMP_Text textodescripcion;

    [Header("Huecos")]
    private int contadorHuecos = 0;
    public SpriteRenderer[] HuecosArte = new SpriteRenderer[5];

    public Image[] ArteCartas = new Image[10];

    [HideInInspector]public int auxiliar = 0;
    public SpriteRenderer[] HuecosOcupados = new SpriteRenderer[10];
    public Button[] BotonesEquipar = new Button[10];
    
    #endregion
    private void Start()
    {
        pinventario.SetActive(false);
      
        for (int i=0; i<HuecosOcupados.Length; i++)
        {
            HuecosOcupados[i].enabled = false;
        }
        for (int i = 0; i < BotonesEquipar.Length; i++)
        {
            if (cartasDisponibles[i].CartaEquipada == true)
            {
                BotonesEquipar[i].interactable = false;
                
            }
        }
        HuecosOcuparse();
    }
    public void Update()
    {
     for(int i=0; i<cartasDisponibles.Length; i++)
        {
            if (cartasDisponibles[i].CartaEncontrada== false)
            {

            }
        }   
    }
    #region Logica Abrir y cerrar el panel
    public void Interactuar(GameObject jugador)
    {
        Debug.Log("Has abierto el inventario.");
        MostrarInventario();
    }
    void MostrarInventario()
    {
        pinventario.SetActive(true);
        Time.timeScale = 0f;
    }
    public void SalirInverntario()
    {
        pinventario.SetActive(false);
        Time.timeScale = 1f;
    }
    #endregion
    public void mostrarDescripcion(int numeroCarta) //muestra la descripcion de las cartas
    {
        textodescripcion.text = cartasDisponibles[numeroCarta].descripcion;
    }
    #region Logica Equiparse Cartas
    public void Limitadorequiparse() //usar esete codigo para denegar que se equipe cartas que no se halla encontrado, usar el dato del scriptable boleano para esto
        //tambien hay que capar cuando el no entre en el numero de huecos restante
    {

    }
    public void DesequiparseCarta() //cada una de las 5 celdas donde se puede equipar las carta tienen un pequeño boton de desequipar, hacer aqui eso( falta por crear esos botones)
    {

    }
    public void EquiparCarta(int numeroCarta) //al darle al boton pone esta carta en true equipada 
    {
        if ( cartasDisponibles[numeroCarta].espaciosOcupa+datosJugador.espaciosOcupados< datosJugador.EspaciosEquipables)
        {
            
        }
        cartasDisponibles[numeroCarta].CartaEquipada = true;
        HuecosArte[contadorHuecos].sprite = ArteCartas[numeroCarta].sprite;
        contadorHuecos++;
        DesabilitarEquipar(numeroCarta);
    }
    public void DesabilitarEquipar(int numeroCarta) //deshabilita el poder acer click en la carta que se acaba de equipar para equiparsela dos veces
    {
      BotonesEquipar[numeroCarta].interactable = false;
        HuecosOcuparse();
    }
    public void HuecosOcuparse() //activa segun el numero de hueco que se han equipado
    {
        auxiliar = 0;
        for(int i=0; i<cartasDisponibles.Length; i++)
        {
            if (cartasDisponibles[i].CartaEquipada == true)
            {
                auxiliar+=cartasDisponibles[i].espaciosOcupa;
            }
        }
        for(int i=0; i<auxiliar; i++)
        {
            HuecosOcupados[i].enabled = true;
        }
    }
    #endregion
}
