using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private float limiteIzquierdo;
    private float limiteDerecho; 

    public Transform jugador;

    public enum Estado { Patrullando, Persiguiendo, Atacando }
    public Estado estadoActual;

    [Header("Movimiento")]
    public float velocidadPatrulla = 1.5f;
    public float velocidadPersecucion = 3.5f;

    [Header("Distancias")]
    public float rangoDeteccion = 6f;
    public float rangoAtaque = 1.2f;

    [Header("Patrulla")]
    public Transform puntoA;
    public Transform puntoB;
    private Transform objetivoActual;

    [Header("Ataque")]
    public float tiempoEntreAtaques = 1.5f;
    private bool puedeAtacar = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        estadoActual = Estado.Patrullando;
        objetivoActual = puntoB;

        limiteIzquierdo = Mathf.Min(puntoA.position.x, puntoB.position.x);
        limiteDerecho = Mathf.Max(puntoA.position.x, puntoB.position.x);
    }

    void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);

        switch (estadoActual)
        {
            case Estado.Patrullando:

                if (distanciaJugador <= rangoDeteccion)
                    estadoActual = Estado.Persiguiendo;

                break;

            case Estado.Persiguiendo:

                if (distanciaJugador <= rangoAtaque)
                    estadoActual = Estado.Atacando;

                else if (distanciaJugador > rangoDeteccion)
                    estadoActual = Estado.Patrullando;

                break;

            case Estado.Atacando:

                if (distanciaJugador > rangoAtaque)
                    estadoActual = Estado.Persiguiendo;

                break;
        }
    }

    void FixedUpdate()
    {
        switch (estadoActual)
        {
            case Estado.Patrullando:
                Patrullar();
                break;

            case Estado.Persiguiendo:
                Perseguir();
                break;

            case Estado.Atacando:
                rb.velocity = Vector2.zero;
                break;
        }
    }

    void Patrullar()
    {
        float direccion = objetivoActual.position.x - transform.position.x;
        rb.velocity = new Vector2(Mathf.Sign(direccion) * velocidadPatrulla, rb.velocity.y);

        Girar(direccion);

        if (Mathf.Abs(direccion) < 0.2f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }

    void Perseguir()
    {
        float direccion = jugador.position.x - transform.position.x;
        float nuevaVelocidad = Mathf.Sign(direccion) * velocidadPersecucion;

        if ((transform.position.x <= limiteIzquierdo && nuevaVelocidad < 0) ||
            (transform.position.x >= limiteDerecho && nuevaVelocidad > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        rb.velocity = new Vector2(nuevaVelocidad, rb.velocity.y);

        Girar(direccion);
    }

    void Girar(float direccion)
    {
        Vector3 escala = transform.localScale;

        if (direccion > 0)
            escala.x = Mathf.Abs(escala.x);
        else if (direccion < 0)
            escala.x = -Mathf.Abs(escala.x);

        transform.localScale = escala;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (estadoActual == Estado.Atacando && puedeAtacar)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Atacar());
            }
        }
    }

    IEnumerator Atacar()
    {
        puedeAtacar = false;

        Debug.Log("Atacando al jugador");

        yield return new WaitForSeconds(tiempoEntreAtaques);

        puedeAtacar = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}

