using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    //AudioMixer para la reproduccion de sonidos.
    public AudioMixer audioMixer;

    //Menu de lista para las resoluciones de pantalla.
    public Dropdown listaResoluciones;

    //Array que guarda la cantidad de resoluciones disponibles.
    Resolution[] resoluciones;

    private void Start()
    {
        //Permite la deteccion y guardado de todas las opciones de resoluciones disponibles, que luego se muestran en un menu tipo lista para elegir.
        resoluciones = Screen.resolutions;
        listaResoluciones.ClearOptions();

        List<string> opciones = new List<string>();

        int indiceResolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if ((resoluciones [i].width == Screen.currentResolution.width) && (resoluciones[i].height == Screen.currentResolution.height))
            {
                indiceResolucionActual = 1;
            }
        }

        listaResoluciones.AddOptions(opciones);
        listaResoluciones.value = indiceResolucionActual;
        listaResoluciones.RefreshShownValue();
    }

    //Metodo para establecer la resolucion elegida, basado en la lista.
    public void SetResolucion (int indiceResolucion)
    {

        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    //Metodo para establecer el valor del volumen.
    public void SetVolumen(float volumen)
    {

        audioMixer.SetFloat("Volumen", volumen);
    }

    //Metodo para establecer la calidad del juego, usando valores de index predefinidos dentro de Unity, al igual que las opciones mas avanzadas de calidad.
    public void SetCalidad(int indiceCalidad)
    {

        QualitySettings.SetQualityLevel(indiceCalidad);
    }

    //Metodo para establecer si el juego se ejecutable en pantalla completa o no.
    public void SetPantallaCompleta(bool esPantallaCompleta)
    {
        Screen.fullScreen = esPantallaCompleta;
    }
}