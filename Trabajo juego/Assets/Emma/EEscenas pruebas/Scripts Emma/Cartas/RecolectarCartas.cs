using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecolectarCartas : MonoBehaviour
{

    public int cartas = 0;
    public TextMeshProUGUI textoCartas; // arrastra aquí tu texto TMP

    public void SumarCarta()
    {
        cartas++;
        if (textoCartas != null)
            textoCartas.text = "Cartas: " + cartas;

        Debug.Log("Cartas recogidas: " + cartas);

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
