using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanioRecibidoJugador : MonoBehaviour
{
    //Cantidad de vida del jugador.
    public int vida = 100;

    //Uso de variables Serialize para el display de UI.
    [SerializeField]Text displayVida;
    [SerializeField]Text textoMuerte;

    void Start()
    {
        //Cuando se inicia el script se muestra la cantidad de vida.
        SetTextoVida();
    }
    
    void Update()
    {
        if (vida <= 0)
        {
            
            Muere();
        }
    }

    //Si el jugador llega a 0HP, se destruye el objeto Jugador y reproduce el sonido de muerte, a la vez que tambien activa la pantalla de continuar.
    void Muere()
    {
        Destroy(gameObject);
        displayVida.text = "0";
        textoMuerte.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Muerte");
    }

    //Conversion a String de la cantidad de HP para la UI.
    void SetTextoVida()
    {

        displayVida.text = vida.ToString();
    }

    //Se controla la disminucion de HP a traves de colisiones, cuando el enemigo toca al jugador este pierde vida, cuando toca un MedKit recupera vida, tambien se incluye la funcion para
    //actualizar la cantidad de HP actual y la reproduccion de los sonidos asignados.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("Colision");
            vida -= 12;
            SetTextoVida();
            FindObjectOfType<AudioManager>().Play("Golpe");
        }

        if (collision.gameObject.tag == "PaqueteVida")
        {
            Debug.Log("Colision Paquete Vida!");
            vida += 25;
            SetTextoVida();
            FindObjectOfType<AudioManager>().Play("Curacion");
        }
    }
}