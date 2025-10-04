using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTD : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemigo dañado. HP restante: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
