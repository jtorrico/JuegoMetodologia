using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanioRecibidoEnemigo : MonoBehaviour {

    //Cantidad de HP de los enemigos.
    public int vida = 45;

    void Start()
    {
        //Valor inicial.
        vida = 45;
    }
    
    void Update()
    {

        if (vida <= 0)
        {
            Destruir();
        }
    }

    void Destruir()
    {
        //Se destruye el objeto cuando la cantidad de HP llega a 0.
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dependiendo del tipo de objeto al cual reciba colision, se disminuye la cantidad de vida en valores fijados.
        Debug.Log("Colision");
    
        if (collision.gameObject.tag == "JugadorPistola")
        {
            vida -= 12;
        }

        if (collision.gameObject.tag == "JugadorRifle")
        {
            vida -= 8;
        }

        if (collision.gameObject.tag == "JugadorEscopeta")
        {
            vida -= 5;
        }
    }
}