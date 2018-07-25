using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlPantallaCarga : MonoBehaviour {

    //Objeto de Pantalla de Carga.
    public GameObject objetoPantallaCarga;

    //Barra de Carga.
    public Slider Barra;

    //Operacion de Sincronizado.
    AsyncOperation sincronizacion;

    public void CargarPantalla(int LVL)
    {
        StartCoroutine(PantalladeCarga(LVL));
    }

    //En al co-rutina, se activa la pantalla de carga y luego, dependiendo del nivel elegido, realiza la operacion de sincronizado junto con la barra de carga, para representar el progreso
    //del cargado del nivel, una vez terminado, permite la activacion de la escena elegida previamente.
    IEnumerator PantalladeCarga(int lvl)
    {
        objetoPantallaCarga.SetActive(true);
        sincronizacion = SceneManager.LoadSceneAsync(lvl);
        sincronizacion.allowSceneActivation = false;

        while (sincronizacion.isDone == false)
        {
            Barra.value = sincronizacion.progress;

            if (sincronizacion.progress == 0.9f)
            {
                Barra.value = 0.9f;
                sincronizacion.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
