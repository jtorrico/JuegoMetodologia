using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    //Uso de vector para la velocidad de la camara.
    private Vector2 velocidad;

    //Uso de floats para un desplazamiento suave de la camara.
    public float tiempoCorrelacionY;
    public float tiempoCorrelacionX;

    //El objeto Player que controla el jugador.
    public GameObject jugador;

    private void Start()
    {
        //Busqueda del objeto con el tag Player.
        jugador = GameObject.FindGameObjectWithTag("Jugador");
    }

    private void FixedUpdate()
    {

        //En fixedupdate, se actualiza la posicion X/Y cada 60 frames.
        float posX = Mathf.SmoothDamp(transform.position.x, jugador.transform.position.x, ref velocidad.x, tiempoCorrelacionX);
        float posY = Mathf.SmoothDamp(transform.position.y, jugador.transform.position.y, ref velocidad.y, tiempoCorrelacionY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}