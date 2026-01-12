using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class UIJuego : MonoBehaviour
{
    #region PanelData
    [Header("Paneles")]
    public GameObject PanelOpciones;
    public GameObject PanelSalirDelJuego;
    public GameObject BotonesGenerales;
    #endregion

    #region VolumenData
    [Header("Volumen")]
    public Slider sliderVolumen;
    public Toggle Tmute;
    private float _valorGuardado;
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
    #region Singleton
    public static UIJuego InstanciaUI { get; private set; }
    private void Awake()
    {
        if (InstanciaUI != null && InstanciaUI != this)
        {
            Destroy(this);
        }
        else
        {
            InstanciaUI = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion
    void Start()
    {
        Time.timeScale = 1f;
        #region PanelesStart
        PanelOpciones.SetActive(false);
        PanelSalirDelJuego.SetActive(false);
        BotonesGenerales.SetActive(false);
        #endregion
        #region VolumenStart
        if (PlayerPrefs.HasKey("volumen"))
        {
            float volumenGuardado = PlayerPrefs.GetFloat("volumen");
            sliderVolumen.value = volumenGuardado;
            AudioListener.volume = volumenGuardado;
            Tmute.isOn = (volumenGuardado == 0);
        }
        else
        {
            PlayerPrefs.SetFloat("volumen", 0.5f);
        }
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
    #region Update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausaJuego();
        }
    }
    #endregion

    #region PanelSalida
    public void SalirJuego()
    {
        PanelSalirDelJuego.SetActive(true);
    }
    public void SiSalir(string nombre)
    {
        SceneManager.LoadScene(nombre);
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
    #region PanelPausa
    public void PausaJuego()
    {
        BotonesGenerales.SetActive(true);
        Time.timeScale = 0f;
    }
    #endregion

    #region Continuar
    public void Continuar()
    {
        Time.timeScale = 1f;
        PanelOpciones.SetActive(false);
        PanelSalirDelJuego.SetActive(false);
        BotonesGenerales.SetActive(false);
    }
    #endregion
    #region Volumen
    public void cambiarValor(float valor)
    {
        PlayerPrefs.SetFloat("volumen", valor); // le damos un valor a la variable unica para que cuando vuelva a entrar ya tenga el nuevo valor
    }
    public void comprobar()
    {
        if (sliderVolumen.value == 0)
        {
            Tmute.isOn = true;
        }
    }
    public void valorSlider()
    {

        if (Tmute.isOn)
        {
            AudioListener.volume = 0;
            sliderVolumen.value = 0;
            //mute.isOn = true;
        }
        else
        {
            AudioListener.volume = sliderVolumen.value;
            _valorGuardado = sliderVolumen.value; //aqui guardamos el nuevo valor que haya tocado el usuario en el slider
            cambiarValor(_valorGuardado); //llamamos a la funcion que cambia el valor de el PlayerPrefs
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
