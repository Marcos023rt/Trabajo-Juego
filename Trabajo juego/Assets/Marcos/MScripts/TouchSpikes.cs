using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSpikes : MonoBehaviour
{
    //este scrip gestiona las diferentes formas que tiene el jugador de recibir daño
    public UIJuego uiJuego;
    public ScriptableJugador jugadorData;
    public GameObject Jugador;
    public int danioSpikes;
    public int danioEnemigo = 2;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Spikes"))
        {
           
            Aparecer();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            jugadorData.VidaActual -= danioEnemigo;
        }
        RecibirDaño();
    }
    private void Aparecer()
    {
        jugadorData.VidaActual -= danioSpikes;
        this.transform.position = jugadorData.jugadorSpawn;
    }
    public void RecibirDaño()
    {
        if (jugadorData.VidaActual <= 0)
        {
            uiJuego.MuerteJugador(Jugador);
        }
    }
}


