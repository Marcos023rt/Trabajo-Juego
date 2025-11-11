using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RecolectarCartas recolector = FindObjectOfType<RecolectarCartas>();
            if (recolector != null)
            {
                recolector.SumarCarta();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("No se encontró RecolectarCartas en la escena.");
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
