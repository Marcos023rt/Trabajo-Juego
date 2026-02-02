using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpikes : MonoBehaviour
{
    public ScriptableJugador jugadorData;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        jugadorData.jugadorSpawn = collision.transform.position;
    }
}
