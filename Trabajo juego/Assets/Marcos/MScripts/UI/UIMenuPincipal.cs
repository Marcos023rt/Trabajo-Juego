using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class UIMenuPincipal : MonoBehaviour
{
    //este scrip gestiona toda la UI del menu principal :)
    #region PanelData
    public GameObject PanelOpciones;
    public GameObject PanelSalirDelJuego;
    public GameObject PanelControles;
    public GameObject CanvasBrillo;
    #endregion 
    #region VolumenData
    private float valorGuardado;
    public Slider SliderVolumen;
    public Toggle Tmute;
    #endregion
    #region BrilloData
    private float brilloGuardado;
    public Image panelBrillo;
    public Slider brilloSlider;
    #endregion
    void Start()
    {
        #region PanelesStart
        PanelOpciones.SetActive(false);
        PanelSalirDelJuego.SetActive(false);
        PanelControles.SetActive(false);
        DontDestroyOnLoad(CanvasBrillo);
        #endregion
        #region VolumenStart
        float volumenGuardado = PlayerPrefs.GetFloat("volumen", 0.5f);
        SliderVolumen.value = volumenGuardado;
        AudioListener.volume = volumenGuardado;
        Tmute.isOn = (volumenGuardado == 0);
        #endregion
        #region BrilloStart
        brilloSlider.value = PlayerPrefs.GetFloat("brillo", 0.0f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.r, panelBrillo.color.r, brilloGuardado);
        #endregion
       
    }
    #region PanelSalida
    public void SalirJuego()
    {
        PanelSalirDelJuego.SetActive(true);
    }
    public void SiSalir()
    {
        Application.Quit();
    }
    public void NoSalir()
    {
        PanelSalirDelJuego.SetActive(false);
    }
    #endregion
    #region PanelOpciones
    public void Opciones()
    {
        PanelOpciones.SetActive(true);
    }
    public void SalirOpciones()
    {
        PanelOpciones.SetActive(false);
    }
    #endregion
    #region PanelControles
    public void Controles()
    {
        PanelControles.SetActive(true);
    }
    public void SalirControles()
    {
        PanelControles.SetActive(false);
    }
    #endregion
    #region Volumen
    public void cambiarValor(float valor)
    {
        valorGuardado = valor;
        PlayerPrefs.SetFloat("volumen", valor); // le damos un valor a la variable unica para que cuando vuelva a entrar ya tenga el nuevo valor
    }
    public void comprobar()
    {
        if (SliderVolumen.value == 0)
        {
            Tmute.isOn = true;
        }
    }
    public void valorSlider()
    {

        if (Tmute.isOn)
        {
            AudioListener.volume = 0;
            SliderVolumen.value = 0;
            //mute.isOn = true;
        }
        else
        {
            AudioListener.volume = SliderVolumen.value;
            valorGuardado = SliderVolumen.value; //aqui guardamos el nuevo valor que haya tocado el usuario en el slider
            cambiarValor(valorGuardado); //llamamos a la funcion que cambia el valor de el PlayerPrefs
            Tmute.isOn = false;
        }
    }
    #endregion
    #region Brillo
        public void CambiarBrillo()
        {
         brilloGuardado = brilloSlider.value;
         PlayerPrefs.SetFloat("brillo", brilloGuardado);
         panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.r, panelBrillo.color.r, brilloSlider.value);
        }
    #endregion
    #region Resolucion

    #endregion
    #region Calidad

    #endregion

    
}
