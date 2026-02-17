using UnityEngine;

public class CardProjectile : MonoBehaviour
{
    
    public ScriptableJugador jugador;
    public scriptableMejoras datosMejora;
    public float speed;
    public float maxDistance = 8f;
    public int damage;
   
    private Vector2 startPos;
    private Vector2 direction;

   
    public int numeroDeGolpesParaCurarse;

    void Start()
    {
        speed = datosMejora.speedcarta;
        damage = datosMejora.danioCarta;
        startPos = transform.position;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        // Movimiento
        transform.Translate(direction * speed * Time.deltaTime);

        // Comprobar distancia recorrida
        float distance = Vector2.Distance(startPos, transform.position);
        if (distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyTD enemy = other.GetComponent<EnemyTD>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                jugador.contadorGolpes += 1;
                Debug.Log(jugador.contadorGolpes);
               
            }

            Destroy(gameObject); // Desaparece al golpear
        }
        else if (!other.CompareTag("Player")) // Evita destruirse al salir del jugador
        {
            Destroy(gameObject);
        }

    }
}
