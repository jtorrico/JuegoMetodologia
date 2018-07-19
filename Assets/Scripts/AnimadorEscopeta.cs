using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorEscopeta : MonoBehaviour {

    //Animador para la reproduccion de las Animacion de la Escopeta (Shotgun).
    Animator AnimacionEscopeta;

    // Use this for initialization
    void Start()
    {
        //Inicializacion del Animador.
        AnimacionEscopeta = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Animacion Escopeta (Shotgun).
        //Animacion de Movimiento.
        //Al presionar y mantener la tecla, cambia el estado de la variable y reproduce la animacion.

        if (Input.GetKeyDown(KeyCode.W))
        {
            AnimacionEscopeta.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AnimacionEscopeta.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimacionEscopeta.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimacionEscopeta.SetInteger("Mover", 1);
        }

        //Cuando se deja de presionar la tecla, cambia el estado y para la animacion.

        if (Input.GetKeyUp(KeyCode.W))
        {
            AnimacionEscopeta.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            AnimacionEscopeta.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            AnimacionEscopeta.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            AnimacionEscopeta.SetInteger("Mover", 0);
        }
    }
}