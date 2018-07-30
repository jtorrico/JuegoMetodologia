using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilPistola : MonoBehaviour {

    //Salud del projectil.
    public int vida = 1;

    void Update()
    {

        if (vida <= 0)
        {
            Destruir();
        }
    }

    void Destruir()
    {

        Destroy(gameObject);
    }

    //En este caso, cada projectil tiene 1 punto de vida, que cuando collision con algun trigger le quita el punto y destruye el objeto.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Colision");

        vida -= 1;
    }
}