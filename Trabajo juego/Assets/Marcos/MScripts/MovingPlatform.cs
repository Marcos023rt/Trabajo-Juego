using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float speed = 2f;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 siguientePosicion;

    private bool yendoAPuntoB = true;
    void Start()
    {
        posA = puntoA.position;
        posB = puntoB.position;

        siguientePosicion = posB;
        transform.position = posA; 
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,siguientePosicion,speed * Time.deltaTime) ;
        if ((transform.position - siguientePosicion).sqrMagnitude < 0.0001f)
        {
            transform.position = siguientePosicion; 
            yendoAPuntoB = !yendoAPuntoB;
            siguientePosicion = yendoAPuntoB ? posB : posA;
        }
    }
}
