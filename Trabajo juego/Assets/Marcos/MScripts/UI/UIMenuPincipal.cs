using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class UIMenuPincipal : MonoBehaviour
{
    //este scrip gestiona toda la UI del menu principal :)
    #region PanelData
    [Header("Paneles")]
    public GameObject PanelOpciones;
    public GameObject PanelSalirDelJuego;
    public GameObject PanelControles;
    public GameObject CanvasBrillo;
    #endregion

    #region VolumenData
    [Header("Volumen")]
    public Slider SliderVolumen;
    public Toggle Tmute;
    private float valorGuardado;
    #endregion
    #region BrilloData
    [Header("Brillo")]
    public Image panelBrillo;
    private float brilloGuardado;
    public Slider brilloSlider;
    #endregion
    #region ResolucionData
    [Header("Resolucion")]
    public TMP_Dropdown resolucionesDropdown;
    private int resolucion;
    Resolution[] resoluciones;
    #endregion
    #region CalidadData
    [Header("Calidad")]
    public TMP_Dropdown DropCalidad;
    private int calidad;
    #endregion
    #region PantallaCompletaData
    [Header("Pantalla Completa")]
    public Toggle pantallaCompleta;
    #endregion
    void Start()
    {
        #region PanelesStart
        PanelOpciones.SetActive(false);
        PanelSalirDelJuego.SetActive(false);
        PanelControles.SetActive(false);
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
        #region ResolucionesStart
        RevisarResoluciones();
        #endregion
        #region CalidadStart
        DropCalidad.ClearOptions();
        DropCalidad.AddOptions(new System.Collections.Generic.List<string>(QualitySettings.names));
        #endregion
        #region PCompletaStart
        pantallaCompleta.isOn = Screen.fullScreen;
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
    public void RevisarResoluciones()
    {
        resoluciones = Screen.resolutions; //se buscan las resoluciones
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
        for (int i = 0; i < resoluciones.Length; i++) //buscamos y guardamos cada resolucion en la lista
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion); //aqui lo anadimos a la lista
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = 1;
            }
        }
        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = resolucionActual;
        resolucionesDropdown.RefreshShownValue();
        resolucionesDropdown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }
    public void cambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropdown.value);
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    #endregion
    #region Calidad
    public void ElegirCalidad(int indice)
    {
        QualitySettings.SetQualityLevel(indice, true);
        PlayerPrefs.SetInt("numeroCalidad", indice);
        PlayerPrefs.Save();
    }
    #endregion
    #region PantallaCompleta
    public void CambiarPantallaCompleta(bool estado)
    {
        Screen.fullScreen = estado;
    }
    #endregion
    #region Cambiar Escena
    public void CambiarEscenas(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    #endregion
}
