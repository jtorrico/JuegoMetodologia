using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoProjectiles : MonoBehaviour {

    //Velocidad maxima del projectil.
    float velocidadMaxima = 40;

	//Metodo utilizado para el movimiento de los projectiles de las armas.
	void Update () {

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, velocidadMaxima * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}