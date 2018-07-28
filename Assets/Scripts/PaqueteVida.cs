using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaqueteVida : MonoBehaviour {

    //Cuando colisiona con el Jugador, el objeto se destruye.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            Destroy(gameObject);
        }
    }
}
