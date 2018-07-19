using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenalina : MonoBehaviour
{

    //Usando colision del tipo Collider 2D y tags para cada tipo de elemento,
    //se destruye el objeto relacionado con este script (en este caso la adrenalina).

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(gameObject);
        }

    }
}
