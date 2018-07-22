using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu: MonoBehaviour {
    
    //Este el AudioSource utilizado para la musica del menu.
    public AudioSource musica;

    public void ChangeBGM (AudioClip music)
    {
        musica.Stop();
        musica.clip = music;
        musica.Play();
    }
}