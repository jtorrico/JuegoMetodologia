using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorDisparaRifle : MonoBehaviour {

    //Variables de cantidad actual de balas, cantidad maxima, delay de recarga, control y animaciones.
    public int cantidadActualBalasRifle;
    public int cantidadMaximaBalasRifle = 30;
    public int retardoRecarga = 1;
    private bool estaRecargando = false;
    public Animator AnimacionRecargaRifle;
    public Animator AnimacionDisparoRifle;

    //Objeto para instanciar los projectiles.
    public GameObject instanciaBala;

    //Variables Serialize del display de Balas para el HUD.
    [SerializeField] Text municionRifleDisplay;
    [SerializeField] Text municionPistolaDisplay;
    [SerializeField] Text municionEscopetaDisplay;

    //Delay por cada disparo.
    public float retrasoDisparo = 0.1f;
    float tiempoEnFrio = 0;

	// Use this for initialization
	void Start ()
    {
        //Inicializacion para la cantidad de balas disponibles.
        cantidadActualBalasRifle = cantidadMaximaBalasRifle;
        tipoMunicion();
	}

    //En caso de que el jugador cambie de arma en medio de la recarga, esta funcion evita que el arma anteriormente
    //deje de funcionar cuando se vuelva a equipar, reiniciando la animacion y el controlador de recarga.
    void OnEnable()
    {

        estaRecargando = false;
        AnimacionRecargaRifle.SetBool("RecargandoRifle", false);
    }

    // Update is called once per frame
    //Controla por cada frame si se esta recargando o no, sino utiliza la co-rutina de recarga, o la funcion de disparo.
    void Update () {

        if (estaRecargando)
            return;

        tipoMunicion();
        tiempoEnFrio -= Time.deltaTime;

        if (cantidadActualBalasRifle == 0 || Input.GetButton("Recarga"))
        {
            StartCoroutine(RecargarRifle());
            return;
        }

        DispararRifle();
	}

    //Metodo para el cambio de HUD dependiendo del arma actual.
    void tipoMunicion()
    {
        if (Input.GetButton("Arma1"))
        {
            municionPistolaDisplay.gameObject.SetActive(true);
            municionRifleDisplay.gameObject.SetActive(false);
            municionEscopetaDisplay.gameObject.SetActive(false);
        }

        if (Input.GetButton("Arma2"))
        {
            municionPistolaDisplay.gameObject.SetActive(false);
            municionRifleDisplay.gameObject.SetActive(true);
            municionEscopetaDisplay.gameObject.SetActive(false);
        }

        if (Input.GetButton("Arma3"))
        {
            municionPistolaDisplay.gameObject.SetActive(false);
            municionRifleDisplay.gameObject.SetActive(false);
            municionEscopetaDisplay.gameObject.SetActive(true);
        }
    }

    //Muestra de la cantidad de balas disponibles a traves de la conversion a String para el display.
    void SetMunicionRifle()
    {
        municionRifleDisplay.text = cantidadActualBalasRifle.ToString();
    }

    //Funcion que permite el disparo de projectiles, con control de la cantidad disponible de balas junto con un delay para evitar que cada arma dispare en milisegundos
    //por cada disparo, se disminuye la cantidad de balas actuales y se actualiza el HUD, se reinicia el delay para evitar lo mencionado anteriormente, y se reproduce el sonido de disparo
    //junto con la instanciacion de cada projectil y la reproduccion de la animacion.
    void DispararRifle()
    {
        if (Input.GetButton("Disparo1") && tiempoEnFrio <= 0)
        {
            //Shoot!
            Debug.Log("Pew!");
            cantidadActualBalasRifle -= 1;
            SetMunicionRifle();
            tiempoEnFrio = retrasoDisparo;

            AnimacionDisparoRifle.SetBool("Disparo", true);
            Instantiate(instanciaBala, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("DisparoRifle");
        }

        if (Input.GetButtonUp("Disparo1"))
        {
            AnimacionDisparoRifle.SetBool("Disparo", false);
        }
    }

    //Es necesario el uso de co-rutinas para las recargas, sino no el arma cargaria en un instante y la animacion de recarga seria irrelevante.
    //Cada vez que se recarga el arma, ya sea presionando un boton o cuando no hay mas balas, la cantidad disponible siempre va a ser cero.
    //Luego de que espere por la cantidad de tiempo asignado en la variable de delay, se asigna a la cantidad disponible con la cantidad maxima,
    //se actualiza el texto y sale de la co-rutina.
    IEnumerator RecargarRifle()
    {
        estaRecargando = true;
        cantidadActualBalasRifle = 0;
        SetMunicionRifle();
        AnimacionRecargaRifle.SetBool("RecargandoRifle", true);
        Debug.Log("Recargando");

        yield return new WaitForSeconds(retardoRecarga);

        AnimacionRecargaRifle.SetBool("RecargandoRifle", false);
        cantidadActualBalasRifle = cantidadMaximaBalasRifle;
        SetMunicionRifle();
        estaRecargando = false;
    }
}