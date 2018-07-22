using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimadorRifle : MonoBehaviour {

    //Animador para la reproduccion de animacion del Rifle.
    Animator AnimacionRifle;

    // Use this for initialization
    void Start ()
    {
        //Inicializacion del Animador.
        AnimacionRifle = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        //Animacion Rifle.
        //Animacion de Movimiento.
        //Al presionar y mantener la tecla, cambia el estado de la variable y reproduce la animacion.

        if (Input.GetKeyDown(KeyCode.W))
        {
            AnimacionRifle.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AnimacionRifle.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimacionRifle.SetInteger("Mover", 1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimacionRifle.SetInteger("Mover", 1);
        }

        //Cuando se deja de presionar la tecla, cambia el estado y para la animacion.

        if (Input.GetKeyUp(KeyCode.W))
        {
           AnimacionRifle.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            AnimacionRifle.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            AnimacionRifle.SetInteger("Mover", 0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            AnimacionRifle.SetInteger("Mover", 0);
        }
    }
}