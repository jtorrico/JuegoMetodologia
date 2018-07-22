using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour {

    //Uso de array para el almacenamiento de los sonidos.
    public ArraySonidos[] sonidos;

    void Awake()
    {
        //Cuando se inicialice el juego, ya sea en el menu o en un nivel, cuando se reproducen por primera vez cada sonido,
        //se guarda en el array con el clip, volumen, pitch, y la opcion de repetir o no.
        foreach (ArraySonidos s in sonidos)
        {
            s.fuente = gameObject.AddComponent<AudioSource>();
            s.fuente.clip = s.sonido;
            s.fuente.volume = s.volumen;
            s.fuente.pitch = s.tono;
            s.fuente.loop = s.repeticion;
        }
    }

    public void Play (string nombre)
    {
        //Cada vez que se vuelve a reproducir un sonido, este lo hace buscando el nombre definido por cada uno.
        ArraySonidos s = Array.Find(sonidos, sound => sound.nombre == nombre);
        s.fuente.Play();
    }
}
