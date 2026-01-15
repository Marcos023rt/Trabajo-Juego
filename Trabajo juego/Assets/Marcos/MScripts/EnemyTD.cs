using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTD : MonoBehaviour
{
    public ScriptableJugador datosGeneralesJugador;
    public GameObject Jugador;
    public int health = 3;
    public int danio = 2;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo dañado. HP restante: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            datosGeneralesJugador.VidaActual -= danio;
            Debug.Log(datosGeneralesJugador.VidaActual);
        }
        if (datosGeneralesJugador.VidaActual <= 0)
        {
          Jugador.SetActive(false);
        }
    }
}
