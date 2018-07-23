using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVidaJefe : MonoBehaviour {

    public GameObject barraVida;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            barraVida.SetActive(true);
        }
    }
}
