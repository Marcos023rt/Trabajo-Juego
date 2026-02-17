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
    public JugadorHeal jugadorHeal;//usado para mejorar los atributos del jugador que se encuentran aqui dentro
    public ScriptableJugador datosJugador; //scriptable general del jugador
    public scriptableMejoras cartaAtributos; //en este scrip estan los valores que cambio opar hacer las mejoras a la carta
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
    }
    #region Logica Abrir y cerrar el panel
    public void Interactuar(GameObject jugador) //entra aqui cada vez que el jugador interactue con el jugador;
    {
        Debug.Log("Has abierto el inventario.");
        resetearMejoras();
        MostrarInventario();
        LimitadorEquiparse();
    }
    void MostrarInventario()
    {
        pinventario.SetActive(true);
        hacerMejoras();
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
    public void LimitadorEquiparse() 
    {
        //usar esete codigo para denegar que se equipe cartas que no se halla encontrado, usar el dato del scriptable boleano para esto
        //tambien hay que capar cuando el no entre en el numero de huecos restante
        //hacer que se limite dos cosas= 
        //que e limite por los huecos que ocupa la carta
        //que se limite si no tiene la carta encontrada
        for (int i = 0; i < cartasDisponibles.Length; i++)
        {
            //en esta funcion ademas hay que comprobar si las cartas entran(en cuanto a espacio), para eso hay que ir comprobando el numero de huecos con el jugador
            //con cada una de las cartas y hacerlas que se desactiven los botones de aquellas que no entren en los espacios que tenga el jugador 
            if (cartasDisponibles[i].CartaEncontrada == false)
            {
                BotonesEquipar[i].interactable = false;
                ArteCartas[i].fillCenter = false;
            }
            else
            {
                if(cartasDisponibles[i].CartaEncontrada == true)
                {
                    BotonesEquipar[i].interactable = true;
                    ArteCartas[i].fillCenter = true;
                    if (cartasDisponibles[i].CartaEquipada == false)
                    {
                        BotonesEquipar[i].interactable = true;
                        if (cartasDisponibles[i].espaciosOcupa + datosJugador.espaciosOcupados <= datosJugador.EspaciosEquipables)
                        {
                            BotonesEquipar[i].interactable = true;
                        }
                        else
                        {
                            BotonesEquipar[i].interactable = false;
                        }
                    }
                    else
                    {
                        if (cartasDisponibles[i].CartaEquipada == true)
                        {
                            BotonesEquipar[i].interactable = false;
                        }
                    }
                }
            }
        }
    }
    public void Desequiparse() 
    {
        //funciona como un reseteo, vacia el invetario entero al darle al boton
        //hay que resetear los srpites de arriba*
        //eliminar los huecos ( de forma visual)
        //hacer que todas el booleano de las cartas "CartaEquipada" sea false *
        //y poner el contador de huecos ocupados, del los datos del jugador, en 0*
        // y llamar a la funcion que limita las cartas*

        datosJugador.espaciosOcupados = 0; //reseteo del valor exterior
        for (int i = 0; i < cartasDisponibles.Length; i++)
        {
            cartasDisponibles[i].CartaEquipada = false; //hacemos que todas las cartas se pongan en no equiparse
        }
        for(int i =0; i<5; i++) //los srpites de arriba se borran
        {
            HuecosArte[i].sprite = null;
        }
        for (int i = 0; i < 10; i++) //los srites de los huecos
        {
            HuecosOcupados[i].enabled = false;
        }
        LimitadorEquiparse();
    }
    public void EquiparCarta(int numeroCarta) //al darle al boton pone esta carta en true equipada 
    {
        cartasDisponibles[numeroCarta].CartaEquipada = true;
        HuecosArte[contadorHuecos].sprite = ArteCartas[numeroCarta].sprite;
        contadorHuecos++;


        datosJugador.espaciosOcupados += cartasDisponibles[numeroCarta].espaciosOcupa; //guardamos lo huecos ocupados en la variable del jugador
        for(int i=0; i< datosJugador.espaciosOcupados; i++) //activamos los huecos ocupados
        {
            HuecosOcupados[i].enabled = true;
        }
        LimitadorEquiparse();
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
    #region Mejoras de las cartas
    public void hacerMejoras()
    {
        if (cartasDisponibles[0].CartaEquipada == true) //si tiene la carta 0 se hacen sus mejoras
        {
            cartaAtributos.speedcarta = 57;
        }
        if (cartasDisponibles[1].CartaEquipada == true) //si tiene la carta 1se hacen sus mejoras
        {

        }
        if (cartasDisponibles[2].CartaEquipada == true) //si tiene la carta 2se hacen sus mejoras
        {
            jugadorHeal.cura = 2;
        }
        if (cartasDisponibles[3].CartaEquipada == true) //si tiene la carta 3 se hacen sus mejoras
        {

        } 
        if (cartasDisponibles[4].CartaEquipada == true) //si tiene la carta 4 se hacen sus mejoras
        {

        }
        if (cartasDisponibles[5].CartaEquipada == true) //si tiene la carta 5 se hacen sus mejoras
        {
            cartaAtributos.danioCarta = 2;
        }
        if (cartasDisponibles[6].CartaEquipada == true) //si tiene la carta 6 se hacen sus mejoras
        {

        }
        if (cartasDisponibles[7].CartaEquipada == true) //si tiene la carta 7 se hacen sus mejoras
        {

        }
        if (cartasDisponibles[8].CartaEquipada == true) //si tiene la carta 8 se hacen sus mejoras
        {
            jugadorHeal.numeroDeGolpesParaCurarse = 2;
        }
        if (cartasDisponibles[9].CartaEquipada == true) //si tiene la carta 9 se hacen sus mejoras
        {

        }
    }
    public void resetearMejoras()
    {
  cartaAtributos.speedcarta = 35;           //0
                                            //1
                                            //2
  jugadorHeal.cura = 1;                     //3
                                            //4
  cartaAtributos.danioCarta = 2;            //5
                                            //6
                                            //7
  jugadorHeal.numeroDeGolpesParaCurarse = 2;//8
                                            //9
    }
    #endregion
}
