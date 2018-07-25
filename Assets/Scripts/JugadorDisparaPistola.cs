using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorDisparaPistola : MonoBehaviour
{

    //Variables que indican la cantidad actual de balas, la cantidad maxima, el delay de recarga, control de recarga, y los animadores para disparo y recarga.
    public int cantidadActualBalasPistola;
    public int balasPistolaCantidadMaxima = 12;
    public int retardoRecarga = 1;
    private bool estaRecargando = false;
    public Animator AnimacionRecargaPistola;
    public Animator AnimacionDisparoPistola;

    //Objeto para la creacion de projectiles.
    public GameObject instanciaBala;
    
    //Textos que indican la cantidad de balas en HUD.
    [SerializeField] Text municionPistolaDisplay;
    [SerializeField] Text municionRifleDisplay;
    [SerializeField] Text municionEscopetaDisplay;

    //Delay por cada disparo.
    public float retrasoDisparo = 0.35f;
    float tiempoEnFrio = 0;

    // Use this for initialization
    //Se inicializa la cantidad de balas actual con la cantidad maxima.
    void Start()
    {

        cantidadActualBalasPistola = balasPistolaCantidadMaxima;
        tipoMunicion();  
    }

    /*En caso de que el jugador cambie de arma en medio de la recarga, esta funcion evita que el arma anteriormente
     deje de funcionar cuando se vuelva a equipar, reiniciando la animacion y el controlador de recarga.*/
    void OnEnable()

    {
        estaRecargando = false;
        AnimacionRecargaPistola.SetBool("RecargandoPistola", false);
    }

    // Update is called once per frame
    //Controla por cada frame si se esta recargando o no, sino utiliza la co-rutina de recarga, o la funcion de disparo.
    void Update()
    {

        if (estaRecargando)
            return;

        tipoMunicion();
        tiempoEnFrio -= Time.deltaTime;

        if (cantidadActualBalasPistola == 0 || Input.GetButton("Recarga"))
        {
            StartCoroutine(recargarPistola());
            return;
        }

        dispararPistola();
    }


    //Para ser posible el cambio de HUD dependiendo del arma que se elige, se utiliza Objetos que representan el HUD para cada arma, cuando se elige uno, se desactivan los otros dos.
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


    //Convierte la cantidad de balas a String para mostrarlo en el HUD, de la misma forma que con la cantidad de HP.
    void SetMunicionPistola()
    {

        municionPistolaDisplay.text = cantidadActualBalasPistola.ToString();
    }

    //Funcion que permite el disparo de projectiles, con control de la cantidad disponible de balas junto con un delay para evitar que cada arma dispare en milisegundos
    //por cada disparo, se disminuye la cantidad de balas actuales y se actualiza el HUD, se reinicia el delay para evitar lo mencionado anteriormente, y se reproduce el sonido de disparo
    //junto con la instanciacion de cada projectil y la reproduccion de la animacion.
    void dispararPistola()
    {

        if (Input.GetButton("Disparo1") && tiempoEnFrio <= 0 && cantidadActualBalasPistola > 0)
        {
            //Shoot!
            Debug.Log("Pew!");
            cantidadActualBalasPistola--;
            SetMunicionPistola();
            tiempoEnFrio = retrasoDisparo;

            AnimacionDisparoPistola.SetBool("Disparo", true);
            Instantiate(instanciaBala, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("DisparoPistola");
        }

        if (Input.GetButtonUp("Disparo1"))
        {
            AnimacionDisparoPistola.SetBool("Disparo", false);
        }
    }

    //Es necesario el uso de co-rutinas para las recargas, sino no el arma cargaria en un instante y la animacion de recarga seria irrelevante.
    //Cada vez que se recarga el arma, ya sea presionando un boton o cuando no hay mas balas, la cantidad disponible siempre va a ser cero.
    //Luego de que espere por la cantidad de tiempo asignado en la variable de delay, se asigna a la cantidad disponible con la cantidad maxima,
    //se actualiza el texto y sale de la co-rutina.
    IEnumerator recargarPistola()
    {

        estaRecargando = true;
        cantidadActualBalasPistola = 0;
        SetMunicionPistola();
        AnimacionRecargaPistola.SetBool("RecargandoPistola", true);
        Debug.Log("Recargando!");

        yield return new WaitForSeconds(retardoRecarga);

        AnimacionRecargaPistola.SetBool("RecargandoPistola", false);
        cantidadActualBalasPistola = balasPistolaCantidadMaxima;
        SetMunicionPistola();
        estaRecargando = false;
    }
}