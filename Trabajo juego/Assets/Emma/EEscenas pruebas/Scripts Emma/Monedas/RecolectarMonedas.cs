using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecolectarMonedas : MonoBehaviour
{
    public int monedas = 0;
    public TextMeshProUGUI textoMonedas;

    public void SumarMoneda()
    {
        monedas++;
        if (textoMonedas != null)
            textoMonedas.text = "Monedas: " + monedas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
