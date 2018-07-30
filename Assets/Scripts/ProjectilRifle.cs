using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilRifle : MonoBehaviour {

    //Cantidad de vida del projectil del Rifle.
    public int vida = 1;

    void Update()
    {

        if (vida <= 0)
        {
            Destruir();
        }
    }

    //Destruccion del Objeto.
    void Destruir()
    {

        Destroy(gameObject);
    }

    //Cuando colision con algun trigger, ya sea una pared o enemigo, el projectil se destruye.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Colision");
        vida -= 1;
    }
}