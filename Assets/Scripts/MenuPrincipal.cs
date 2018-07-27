using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour {

    //Como en el Menu se utiliza un solo AudioSource, que representa la musica del juego, y al no estar relacionada con el array de Sonidos,
    //se tiene que destruir cada vez que se elige un nivel.

    //Cada uno de estos metodos son representados en el inspector, que luego se le relaciona la funcion y accion correspondiente.
    public void JugarNivel1()
    {
        AudioMenu.Destroy(gameObject);
    }

    public void JugarNivel2()
    {
        AudioMenu.Destroy(gameObject);
    }

    public void JugarNivel3()
    {
        AudioMenu.Destroy(gameObject);
    }

    public void SalirJuego()
    {
        Debug.Log("Salir!");
        Application.Quit();
    }
}