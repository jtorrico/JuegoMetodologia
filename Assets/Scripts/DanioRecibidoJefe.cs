using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanioRecibidoJefe : MonoBehaviour {

    //Cantidad de vida del enemigo.
    public float vidaActual = 1500;
    private float vida;
    public GameObject HPB;
    public Image barraVida;
    public Text cantidadVida;

    void Start()
    {
        //Cada vez que se ejecuta el script, se le asigna el valor a la variable.
        vida = vidaActual;
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
        //Si llega a 0HP, se destruye el objeto de la escena.
        Destroy(gameObject);
        DestroyObject(HPB);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Dependiendo del tipo de collision que reciba, diferenciadose a traves de tags, este disminuira la cantidad de vida con ciertos valores fijados.
        Debug.Log("Colision");
    
        if (collision.gameObject.tag == "JugadorPistola")
        {
            vida -= 12;
            cantidadVida.text = vida.ToString();
            barraVida.fillAmount = vida / vidaActual;
        }

        if (collision.gameObject.tag == "JugadorRifle")
        {
            vida -= 8;
            cantidadVida.text = vida.ToString();
            barraVida.fillAmount = vida / vidaActual;
        }

        if (collision.gameObject.tag == "JugadorEscopeta")
        {
            vida -= 5;
            cantidadVida.text = vida.ToString();
            barraVida.fillAmount = vida / vidaActual;
        }
    }
}