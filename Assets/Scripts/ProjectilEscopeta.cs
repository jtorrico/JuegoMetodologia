using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEscopeta : MonoBehaviour {

    //Cantidad de vida del projectil.
    private int vida = 1;

    void Update()
    {

        if (vida <= 0)
        {
            Destruir();
        }
    }

    //Destruccion del objeto.
    void Destruir()
    {

        Destroy(gameObject);
    }

    //Cuando el projectil colisione con cualquier trigger, este se destruira.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Colision");
        vida -= 1;
    }
}