using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform firePoint; // lugar desde donde se lanza la carta
    public float attackCooldown = 0.3f;

    private float lastAttackTime = 0f;
    private Vector2 facingDirection = Vector2.right; // dirección inicial

    void Update()
    {
        // Detectar dirección (izquierda/derecha)
        if (Input.GetAxisRaw("Horizontal") > 0)
            facingDirection = Vector2.right;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            facingDirection = Vector2.left;

        // Lanzar carta
        if (Input.GetKeyDown(KeyCode.D) && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        GameObject card = Instantiate(cardPrefab, firePoint.position, Quaternion.identity);
        card.GetComponent<CardProjectile>().SetDirection(facingDirection);

        lastAttackTime = Time.time;
    }
}
