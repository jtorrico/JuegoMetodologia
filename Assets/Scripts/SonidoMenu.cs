using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoMenu : MonoBehaviour {

    //Barra de Sonido.
    public Slider Volumen;
    public AudioSource MusicaMenu;

    void Update()
    {
        //Actualiza en cada frame, el valor del sonido en tiempo real.
        MusicaMenu.volume = Volumen.value;
    }
}