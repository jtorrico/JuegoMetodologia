using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

    //Comprobador para saber si el juego esta pausado o no.
    public static bool juegoEstaPausado = false;

    //Objeto que representa al menu.
    public GameObject menuPausaUI;

    //Todos estos campos son Serialized, lo que significa es que no pueden ser accedidos desde el inspector, estos representan las funciones del jugador.
    [SerializeField]
    ApuntadoMouse ControlMouse;

    [SerializeField]
    JugadorDisparaPistola ControlPistola;

    [SerializeField]
    JugadorDisparaRifle ControlRifle;

    [SerializeField]
    JugadorDisparaEscopeta ControlEscopeta;

    [SerializeField]
    InstanciaProjectilEscopeta ControlInstanciaEscopeta;

    [SerializeField]
    MovimientoJugador ControlMovimiento;

    [SerializeField]
    CambiarArma ControlSwitch;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoEstaPausado)
            {
                continuarJuego();
            }
            else
            {
                pausaJuego();
            }     
        }
    }

    //Aca se desactiva el Menu de Pausa y se activan todas las funciones del jugador, reanudando el tiempo tambien.
    public void continuarJuego()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1;
        juegoEstaPausado = false;
        ControlMouse.enabled = true;
        ControlPistola.enabled = true;
        ControlRifle.enabled = true;
        ControlEscopeta.enabled = true;
        ControlInstanciaEscopeta.enabled = true;
        ControlMovimiento.enabled = true;
        ControlSwitch.enabled = true;
    }

    //Se activa el Menu de Pausa, se desabilitan todas las funciones del jugador, y se pausa el tiempo.
    public void pausaJuego()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        juegoEstaPausado = true;
        ControlMouse.enabled = false;
        ControlPistola.enabled = false;
        ControlRifle.enabled = false;
        ControlEscopeta.enabled = false;
        ControlInstanciaEscopeta.enabled = false;
        ControlMovimiento.enabled = false;
        ControlSwitch.enabled = false;
    }
	
    //Metodo que carga el Menu Principal si se elige la opcion de Volver al Menu, desde el menu de pausa.
	public void salirAMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //Metodo que cierra la aplicacion cuando se eliga la opcion de Salir del Juego, desde el menu de pausa.
    public void salirJuego()
    {
        Application.Quit();
    }
}
