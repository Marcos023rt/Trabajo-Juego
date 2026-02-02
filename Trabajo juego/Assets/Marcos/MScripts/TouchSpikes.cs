using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSpikes : MonoBehaviour
{
    //este scrip gestiona las diferentes formas que tiene el jugador de recibir daño
    private UIJuego uiJuego; //la variable que usare para guardar el objet del canvasUIss
    public ScriptableJugador jugadorData;
    public GameObject Jugador;
    public int danioSpikes;
    public int danioEnemigo = 2;
    private void Start()
    {
        GameObject obj = GameObject.Find("CanvasUI");//esto es para encontrar el canvas que es un singletone 
        //por eso aparece en diferentes escenas y tengo que meterlo de otra forma que no sea atraves del inspector
        //pues en la 2º escena no esta el game objetc pero cuando se cargue este start se metera el game oebjet de canvasui en este dato par poder usarlo
        uiJuego = obj.GetComponent<UIJuego>();
    }
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


