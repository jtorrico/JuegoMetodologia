using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour {

    //Mensaje que muestra que se esta cargando el siguiente nivel.
    public GameObject mensaje;

    //Metodo que detecta la colision del jugador en un punto marcado en el nivel actual, al activarse, muestra la advertencia y carga el siguiente nivel.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            mensaje.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
