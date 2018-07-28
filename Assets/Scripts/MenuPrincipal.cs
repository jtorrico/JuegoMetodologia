using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour {

    //Controla la funcion del boton Salir para cerrar el juego desde el Menu Principal.
    public void SalirJuego()
    {
        Debug.Log("Salir!");
        Application.Quit();
    }
}
