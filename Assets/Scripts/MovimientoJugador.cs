using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {

    //Velocidad del Jugador.
    public float velocidad = 5;

    //RigidBody, utilizado para las colisiones y uso de Gravedad, entre otros.
    public Rigidbody2D rb;

    //Variable para el uso de la activacion de la Adrenalina.
    private bool empujon = false;

    void OnEnable()

    {
        empujon = false;
    }

    void FixedUpdate()
    {
        //Aca se permite el movimiento del jugador usando las teclas de movimiento, a traves del RigidBody.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }

    //Colision para la activacion de la Adrenalina.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Adrenalina")
        {
            StartCoroutine(EmpujeAdrenalina());
        }
    }
    
    //Co-rutina que permite el aumento de velocidad por una cantidad finita de tiempo.
    IEnumerator EmpujeAdrenalina()
    {
        empujon = true;
        velocidad = 10;
        Debug.Log("Empujon de Velocidad!");
        FindObjectOfType<AudioManager>().Play("Adrenalina");

        yield return new WaitForSeconds(10);

        FindObjectOfType<AudioSource>().Stop();
        velocidad = 5;
        Debug.Log("Normalizando Velocidad..");
        empujon = false;
    }
}