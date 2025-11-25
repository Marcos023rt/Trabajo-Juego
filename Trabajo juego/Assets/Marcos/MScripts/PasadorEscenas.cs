using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasadorEscenas : MonoBehaviour
{
    public string escena;
    #region Cambiar Escena
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CambiarEscenas(escena);
        }
    }
    public void CambiarEscenas(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    #endregion
}
