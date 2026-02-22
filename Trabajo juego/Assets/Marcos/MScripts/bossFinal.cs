using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFinal : MonoBehaviour
{
    public Transform jugador;
    private Rigidbody2D rb;

    [Header("Movimiento")]
    public float velocidadCaminar = 2f;
    public float velocidadAcercarse = 4f;

    [Header("Tiempos")]
    public float tiempoEntreAtaques = 2f;

    [Header("Salto")]
    public float fuerzaSalto = 12f;
    public float velocidadAerea = 5f;

    [Header("Bastón")]
    public GameObject hitboxBaston; // GameObject hijo con collider y sprite
    public float duracionBaston = 0.5f;
    private Transform transformBaston;

    private bool ejecutandoAtaque = false;

    public enum TipoAtaque
    {
        SaltoAplastador,
        Baston,
        Combo
    }

    private TipoAtaque ultimoAtaque;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (hitboxBaston != null)
        {
            hitboxBaston.SetActive(false);
            transformBaston = hitboxBaston.transform;
        }

        StartCoroutine(BucleIA());
    }

    void Update()
    {
        if (!ejecutandoAtaque)
        {
            CaminarNormal();
        }
    }

    IEnumerator BucleIA()
    {
        yield return new WaitForSeconds(2f); // pequeña intro

        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreAtaques);

            TipoAtaque ataque = ElegirAtaque();
            yield return StartCoroutine(EjecutarAtaque(ataque));
        }
    }

    void CaminarNormal()
    {
        float direccion = Mathf.Sin(Time.time) > 0 ? 1 : -1;
        rb.velocity = new Vector2(direccion * velocidadCaminar, rb.velocity.y);

        GirarHacia(direccion);
    }

    TipoAtaque ElegirAtaque()
    {
        List<TipoAtaque> ataques = new List<TipoAtaque>
        {
            TipoAtaque.SaltoAplastador,
            TipoAtaque.Baston,
            TipoAtaque.Combo
        };

        ataques.Remove(ultimoAtaque);

        TipoAtaque nuevo = ataques[Random.Range(0, ataques.Count)];
        ultimoAtaque = nuevo;

        return nuevo;
    }

    IEnumerator EjecutarAtaque(TipoAtaque ataque)
    {
        ejecutandoAtaque = true;
        rb.velocity = Vector2.zero;

        switch (ataque)
        {
            case TipoAtaque.SaltoAplastador:
                yield return StartCoroutine(AtaqueSaltoAplastador());
                break;

            case TipoAtaque.Baston:
                yield return StartCoroutine(AtaqueBaston());
                break;

            case TipoAtaque.Combo:
                yield return StartCoroutine(AtaqueCombo());
                break;
        }

        ejecutandoAtaque = false;
    }

    // ------------------ ATAQUES ------------------

    IEnumerator AtaqueSaltoAplastador()
    {
        yield return new WaitForSeconds(0.5f);

        rb.velocity = new Vector2(0, fuerzaSalto);

        yield return new WaitForSeconds(0.2f);

        float direccion = jugador.position.x - transform.position.x;
        GirarHacia(direccion);

        rb.velocity = new Vector2(Mathf.Sign(direccion) * velocidadAerea, rb.velocity.y);

        yield return new WaitUntil(() => Mathf.Abs(rb.velocity.y) < 0.1f);
    }

    IEnumerator AtaqueBaston()
    {
        float direccion = jugador.position.x - transform.position.x;
        GirarHacia(direccion);

        // Acercarse al jugador
        rb.velocity = new Vector2(Mathf.Sign(direccion) * velocidadAcercarse, 0);
        yield return new WaitForSeconds(0.5f);

        rb.velocity = Vector2.zero;

        // Wind-up
        yield return new WaitForSeconds(0.4f);

        // Activar hitbox y sprite del bastón
        if (hitboxBaston != null)
            yield return StartCoroutine(ActivarBaston());

        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator AtaqueCombo()
    {
        yield return new WaitForSeconds(0.5f);

        rb.velocity = new Vector2(0, fuerzaSalto);
        yield return new WaitForSeconds(0.2f);

        float direccion = jugador.position.x - transform.position.x;
        GirarHacia(direccion);

        rb.velocity = new Vector2(Mathf.Sign(direccion) * velocidadAerea, rb.velocity.y);

        // Mientras cae, activar hitbox bastón
        if (hitboxBaston != null)
            hitboxBaston.SetActive(true);

        yield return new WaitUntil(() => Mathf.Abs(rb.velocity.y) < 0.1f);

        // Desactivar hitbox al aterrizar
        if (hitboxBaston != null)
            hitboxBaston.SetActive(false);

        yield return new WaitForSeconds(0.3f);
    }

    // ------------------ FUNCIONES AUXILIARES ------------------

    IEnumerator ActivarBaston()
    {
        hitboxBaston.SetActive(true);
        yield return new WaitForSeconds(duracionBaston);
        hitboxBaston.SetActive(false);
    }

    void GirarHacia(float direccion)
    {
        // Girar solo horizontalmente usando Y
        if (direccion > 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);  // mirando derecha
        else if (direccion < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0); // mirar izquierda

        // Girar el bastón para que siga al boss
        if (transformBaston != null)
        {
            Vector3 escala = transformBaston.localScale;
            escala.x = Mathf.Abs(escala.x); // asegurarse que X positiva
            transformBaston.localScale = escala;

            // Ajustar rotación del bastón
            transformBaston.rotation = transform.rotation;
        }
    }
}