using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTD : MonoBehaviour
{
    public ScriptableJugador datosJugador;
    public GameObject Jugador;
    public int health = 3;
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            int dineroGanadoAlMatar = Random.Range(3, 8);
            Destroy(gameObject);
            datosJugador.Dinero += dineroGanadoAlMatar;
        }
    }
}
