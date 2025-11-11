using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RecolectarMonedas recolector = FindObjectOfType<RecolectarMonedas>();
            if (recolector != null)
            {
                recolector.SumarMoneda();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("No se encontró RecolectarMonedas en la escena.");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
