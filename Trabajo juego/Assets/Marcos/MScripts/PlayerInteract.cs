using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInteract : MonoBehaviour
{
    public float radioDeteccion = 1.2f;
    public LayerMask capaInteractuable;
    public KeyCode teclaInteraccion = KeyCode.E;

    private List<interactive> objetosCercanos = new List<interactive>();
    private interactive objetoCercano;

    void Update()
    {
        DetectarObjetosCercanos();

        if (objetoCercano != null && Input.GetKeyDown(teclaInteraccion))
        {
            EjecutarAccion(objetoCercano);
        }
    }

    void DetectarObjetosCercanos()
    {
        Collider2D[] colisiones = Physics2D.OverlapCircleAll(transform.position, radioDeteccion, capaInteractuable);

        objetosCercanos.Clear();

        foreach (var col in colisiones)
        {
            interactive inter = col.GetComponent<interactive>();
            if (inter != null)
            {
                objetosCercanos.Add(inter);
            }
        }

        objetoCercano = objetosCercanos.Count > 0 ? objetosCercanos[0] : null;
    }

    void EjecutarAccion(interactive objeto)
    {
        switch (objeto)
        {
            case Vendedor vendedor:
                vendedor.Interactuar(this.gameObject);
                break;

            case CartaMundo cartaMundo:
                cartaMundo.Interactuar(this.gameObject);
                break;
            case ZonaDescanso zonaDescanso:
                zonaDescanso.Interactuar(this.gameObject);
                break;

            default:
                Debug.LogWarning("Objeto interactuable no reconocido");
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
}
