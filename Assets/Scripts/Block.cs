using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject bloqueo;
    public GameObject bloqueoTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            bloqueo.SetActive(true);
            bloqueoTrigger.SetActive(false);
        }
    }
}
