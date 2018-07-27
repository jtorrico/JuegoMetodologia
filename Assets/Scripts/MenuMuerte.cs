using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuMuerte : MonoBehaviour {

    public void SalirJuego()
    {
        //Cuando se elige salir al menu, el Adminitrador de Escenas busca y carga la Escena llamada Menu.
        SceneManager.LoadScene("Menu");
    }

    public void Reiniciar()
    {
        //Cuando se elige reiniciar el nivel, este guarda la escena actual en una variable para luego volver a cargarla. 
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}