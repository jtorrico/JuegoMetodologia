using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour {

    //Aca se cuenta la cantidad de enemigos restantes durante el 3er Nivel.
    //Cuando el jugador mata a todos los enemigos, se activa el mensaje de fin del juego.
    private int enemigosRestantes = 0;
    public GameObject mensajeJuego;
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        enemigosRestantes = enemigos.Length;

        if (enemigosRestantes == 0)
        {
            mensajeJuego.SetActive(true);
        }
    }
}
