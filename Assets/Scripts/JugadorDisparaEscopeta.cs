using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorDisparaEscopeta : MonoBehaviour {

    //Variables de cantidad actual de balas, cantidad maxima, delay de recarga, control y animaciones.
    public int municionEscopetaActual;
    public int municionEscopetaMaxima = 8;
    public float retrasoRecarga = 1.5f;
    private bool estaRecargando = false;
    public Animator AnimacionRecargaEscopeta;
    public Animator AnimacionDisparoEscopeta;

    //Objeto para instanciar los projectiles.
    public GameObject instanciaBala;

    //Variables Serialize del display de Balas para el HUD.
    [SerializeField] Text municionPistolaDisplay;
    [SerializeField] Text municionRifleDisplay;
    [SerializeField] Text municionEscopetaDisplay;

    //Delay por cada disparo.
    public float retrasoDisparo = 0.35f;
    float tiempoEnFrio = 0;

	// Use this for initialization
	void Start ()
    {
        //Inicializacion para la cantidad de balas disponibles.
        municionEscopetaActual = municionEscopetaMaxima;
        tipoMunicion();
	}

    //En caso de que el jugador cambie de arma en medio de la recarga, esta funcion evita que el arma anteriormente
    //deje de funcionar cuando se vuelva a equipar, reiniciando la animacion y el controlador de recarga.
    void OnEnable()
    {
        estaRecargando = false;
        AnimacionRecargaEscopeta.SetBool("RecargandoEscopeta", false);
    }

    // Update is called once per frame
    //Controla por cada frame si se esta recargando o no, sino utiliza la co-rutina de recarga, o la funcion de disparo.
    void Update ()
    {

        if (estaRecargando)
            return;

        tipoMunicion();
        tiempoEnFrio -= Time.deltaTime;

        if (municionEscopetaActual == 0 || Input.GetButton("Recarga"))
        {
            StartCoroutine(recargarEscopeta());
            return;
        }

        dispararEscopeta();
	}

    //Metodo para el cambio de HUD dependiendo del arma actual.
    void tipoMunicion()
    {

        if (Input.GetButton("Arma3"))
        {
            municionEscopetaDisplay.gameObject.SetActive(true);
            municionPistolaDisplay.gameObject.SetActive(false);
            municionRifleDisplay.gameObject.SetActive(false);
        }

        if (Input.GetButton("Arma2"))
        {
            municionEscopetaDisplay.gameObject.SetActive(false);
            municionPistolaDisplay.gameObject.SetActive(false);
            municionRifleDisplay.gameObject.SetActive(true);
        }

        if (Input.GetButton("Arma1"))
        {
            municionEscopetaDisplay.gameObject.SetActive(false);
            municionPistolaDisplay.gameObject.SetActive(true);
            municionRifleDisplay.gameObject.SetActive(false);
        }
    }

    //Muestra de la cantidad de balas disponibles a traves de la conversion a String para el display.
    void SetMunicionEscopeta()
    {

        municionEscopetaDisplay.text = municionEscopetaActual.ToString();
    }

    //Funcion que permite el disparo de projectiles, con control de la cantidad disponible de balas junto con un delay para evitar que cada arma dispare en milisegundos
    //por cada disparo, se disminuye la cantidad de balas actuales y se actualiza el HUD, se reinicia el delay para evitar lo mencionado anteriormente, y se reproduce el sonido de disparo
    //junto con la instanciacion de cada projectil y la reproduccion de la animacion.
    void dispararEscopeta()
    {

        if (Input.GetButton("Disparo1") && tiempoEnFrio <= 0)
        {
            //Dispara!
            Debug.Log("Pew!");
            municionEscopetaActual -= 1;
            SetMunicionEscopeta();
            tiempoEnFrio = retrasoDisparo;
            FindObjectOfType<AudioManager>().Play("DisparoEscopeta");

            AnimacionDisparoEscopeta.SetBool("Shot", true);
            Instantiate(instanciaBala, transform.position, transform.rotation);

        }

        if (Input.GetButtonUp("Disparo1"))
        {
            AnimacionDisparoEscopeta.SetBool("Disparo", false);
        }
    }

    //Es necesario el uso de co-rutinas para las recargas, sino no el arma cargaria en un instante y la animacion de recarga seria irrelevante.
    //Cada vez que se recarga el arma, ya sea presionando un boton o cuando no hay mas balas, la cantidad disponible siempre va a ser cero.
    //Luego de que espere por la cantidad de tiempo asignado en la variable de delay, se asigna a la cantidad disponible con la cantidad maxima,
    //se actualiza el texto y sale de la co-rutina.
    IEnumerator recargarEscopeta()
    {

        estaRecargando = true;
        municionEscopetaActual = 0;
        SetMunicionEscopeta();
        AnimacionRecargaEscopeta.SetBool("RecargandoEscopeta", true);
        Debug.Log("Recargando");

        yield return new WaitForSeconds(retrasoRecarga);

        AnimacionRecargaEscopeta.SetBool("RecargandoEscopeta", false);
        municionEscopetaActual = municionEscopetaMaxima;
        SetMunicionEscopeta();
        estaRecargando = false;
    }
}