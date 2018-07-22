using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class ArraySonidos{

    //Array que contiene el nombre del archivo, el clip de sonido, rango, pitch y loop para personalizacion de la reproduccion de cada sonido.
    public string nombre;

    public AudioClip sonido;

    [Range (0f, 1f)]
    public float volumen;

    [Range (.1f, 3f)]
    public float tono;

    public bool repeticion;

    [HideInInspector]
    public AudioSource fuente;
}
