using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInteract : MonoBehaviour
{
    public float radioDeteccion = 1f;          
    public LayerMask capaInteractuable;  // Capa que deberas asignar y poner a las diferentes cosas interactuables
    public KeyCode teclaInteraccion = KeyCode.E;

    private interactive objetoCercano;

    void Update()
    {
        DetectarObjetoCercano();

        if (objetoCercano != null && Input.GetKeyDown(teclaInteraccion))
        {
            objetoCercano.Interactuar(this.gameObject);
        }
    }

    void DetectarObjetoCercano()
    {
        // Detecta colliders cercanos en un radio
        Collider2D[] colisiones = Physics2D.OverlapCircleAll(transform.position, radioDeteccion, capaInteractuable);

        if (colisiones.Length > 0)
        {
            objetoCercano = colisiones[0].GetComponent<interactive>();
        }
        else
        {
            objetoCercano = null;
        }
    }

    void OnDrawGizmosSelected() //esto es para poder ver el radio
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
}
