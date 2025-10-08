using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTD : MonoBehaviour
{
    public float health = 3;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Enemigo dañado. HP restante: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
