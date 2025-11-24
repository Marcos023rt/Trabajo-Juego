using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDescanso : MonoBehaviour, interactive
{
    [Header("Cartas equipables")]
    [Tooltip("Meter las diferentes cartas que se han creado del ScriptableObjet")] public PlantillaCartas[] cartasDisponibles;
    public GameObject pinventario;
    private void Start()
    {
        pinventario.SetActive(false);
    }
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
}
